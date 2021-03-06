﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Novacode;
using System.Globalization;

namespace LBCFUBL.Services
{
    public class DocXGlobalReport : Report
    {
        protected DocXGlobalReport(DateTime from, DateTime to)
            : base("global", "docx", from, to)
        {
        }

        private static void setTableStyle(Novacode.Table table)
        {
            table.Design = TableDesign.LightGridAccent1;
            table.AutoFit = AutoFit.ColumnWidth;
        }

        private string currency(double price)
        {
            return price.ToString("C", CultureInfo.CreateSpecificCulture("fr-FR"));
        }

        public static DocXGlobalReport CreateReport(DateTime from, DateTime to)
        {
            DocXGlobalReport report = new DocXGlobalReport(from, to);
            
            using (DocX doc = DocX.Create(report.FilePath))
            {
                report.Fill(doc);
                doc.Save();
            }

            return report;
        }

        private void Fill(DocX doc)
        {
            doc
                .InsertParagraph()
                .Heading(HeadingType.Heading1)
                .Append("Laboratoire des assistants - Rapport des comptes");

            doc.InsertSection();
            doc
                .InsertParagraph()
                .Heading(HeadingType.Heading2)
                .Append("Information générales");
            FillGlobalInfos(doc);

            doc.InsertSection();
            doc
                .InsertParagraph()
                .Heading(HeadingType.Heading2)
                .Append(string.Format("Dettes des assistants (au {0})", to.ToString("dd-MM-yyyy")));
            FillUsersInfos(doc);

            doc.InsertSection();
            doc
                .InsertParagraph()
                .Heading(HeadingType.Heading2)
                .Append("Accomptes");
            FillAccounts(doc);

            doc.InsertSection();
            doc
                .InsertParagraph()
                .Heading(HeadingType.Heading2)
                .Append("Détails d'achats");
            FillPurchases(doc);
        }

        private void FillGlobalInfos(DocX doc)
        {
            LBCFUBL_WCF.DBO.Account[] accounts = Helper.GetAccountClient().GetAccounts();
            LBCFUBL_WCF.DBO.Purchase[] purchases = Helper.GetPurchaseClient().GetPurchases();

            double sumAccountsBefore = accounts.Where(x => x.date <= from).Sum(x => x.argent) -
                purchases.Where(x => x.date < from).Sum(x => x.Product.cost_with_margin);

            double sumAccountsAfter = accounts.Where(x => x.date <= to).Sum(x => x.argent) -
                purchases.Where(x => x.date < to).Sum(x => x.Product.cost_with_margin);

            double totalAccounts = accounts.Where(x => x.date <= to).Sum(x => x.argent);

            double totalWithoutMargin = purchases.Where(x => from <= x.date && x.date <= to).Sum(x => x.Product.cost_without_margin);
            double total = purchases.Where(x => from <= x.date && x.date <= to).Sum(x => x.Product.cost_with_margin);

            doc.InsertParagraph()
                .Append("Période : ").Append(string.Format("du {0} au {1}.", from.ToString("dd-MM-yyyy"), to.ToString("dd-MM-yyyy"))).Bold().AppendLine()
                .Append(string.Format("Caisse au {0} : ", from.ToString("dd-MM-yyyy"))).Append(currency(sumAccountsBefore)).Bold().AppendLine()
                .Append(string.Format("Caisse au {0} : ", to.ToString("dd-MM-yyyy"))).Append(currency(sumAccountsAfter)).Bold().AppendLine()
                .Append("Total accomptes des assistants : ").Append(currency(totalAccounts)).Bold().AppendLine()
                .Append("Total achats : ").Append(currency(totalWithoutMargin)).Bold().AppendLine()
                .Append("Total achats (+ marges) : ").Append(currency(total)).Bold().AppendLine()
                .Append("Total bénéfices : ").Append(currency(total - totalWithoutMargin)).Bold().AppendLine();
        }

        private void FillUsersInfos(DocX doc)
        {
            IEnumerable<LBCFUBL_WCF.DBO.User> users = Helper
                .GetUserClient()
                .GetUsers()
                .OrderBy(x => x.login);

            Novacode.Table table = doc.AddTable(users.Count() + 1, 4);
            setTableStyle(table);

            table.Rows[0].Cells[0].InsertParagraph().Append("Login").Bold();
            table.Rows[0].Cells[1].InsertParagraph().Append("Accompte").Bold();
            table.Rows[0].Cells[2].InsertParagraph().Append("Dette").Bold();
            table.Rows[0].Cells[3].InsertParagraph().Append("Balance").Bold();

            int i = 1;
            foreach (LBCFUBL_WCF.DBO.User user in users)
            {
                double totalAccount = Helper
                    .GetAccountClient()
                    .GetAccountsForLogin(user.login)
                    .Where(x => x.date <= to)
                    .Sum(x => x.argent) - Helper
                    .GetPurchaseClient()
                    .GetPurchasesForLogin(user.login)
                    .Where(x => x.date <= from)
                    .Sum(x => x.Product.cost_with_margin);

                double totalPurchases = Helper
                    .GetPurchaseClient()
                    .GetPurchasesForLogin(user.login)
                    .Where(x => x.date >= from && x.date <= to)
                    .Sum(x => x.Product.cost_with_margin);

                table.Rows[i].Cells[0].InsertParagraph().Append(user.login);
                table.Rows[i].Cells[1].InsertParagraph().Append(currency(totalAccount));
                table.Rows[i].Cells[2].InsertParagraph().Append(currency(totalPurchases));
                table.Rows[i].Cells[3].InsertParagraph().Append(currency(totalAccount - totalPurchases));

                i++;
            }

            doc.InsertTable(table);
        }

        private void FillAccounts(DocX doc)
        {
            IEnumerable<LBCFUBL_WCF.DBO.Account> accounts = Helper
                .GetAccountClient()
                .GetAccounts()
                .OrderBy(x => x.login)
                .Where(x => x.date >= from && x.date <= to);

            Novacode.Table table = doc.AddTable(accounts.Count() + 1, 3);
            setTableStyle(table);

            table.Rows[0].Cells[0].InsertParagraph().Append("Login").Bold();
            table.Rows[0].Cells[1].InsertParagraph().Append("Date").Bold();
            table.Rows[0].Cells[2].InsertParagraph().Append("Argent").Bold();

            int i = 1;
            foreach (LBCFUBL_WCF.DBO.Account account in accounts)
            {
                table.Rows[i].Cells[0].InsertParagraph().Append(account.login);
                table.Rows[i].Cells[1].InsertParagraph().Append(account.date.ToString("dd-MM-yyyy hh:mm"));
                table.Rows[i].Cells[2].InsertParagraph().Append(currency(account.argent));
                i++;
            }

            doc.InsertTable(table);
        }

        private void FillPurchases(DocX doc)
        {
            IEnumerable<LBCFUBL_WCF.DBO.Purchase> purchases = Helper
                .GetPurchaseClient()
                .GetPurchases()
                .OrderBy(x => x.date)
                .OrderBy(x => x.login)
                .ThenBy(x => x.Product.name)
                .Where(x => x.date >= from && x.date <= to);

            Novacode.Table table = doc.AddTable(purchases.Count() + 1, 4);
            setTableStyle(table);

            table.Rows[0].Cells[0].InsertParagraph().Append("Login").Bold();
            table.Rows[0].Cells[1].InsertParagraph().Append("Date").Bold();
            table.Rows[0].Cells[2].InsertParagraph().Append("Produit").Bold();
            table.Rows[0].Cells[3].InsertParagraph().Append("Prix").Bold();

            int i = 1;
            foreach (LBCFUBL_WCF.DBO.Purchase purchase in purchases)
            {
                table.Rows[i].Cells[0].InsertParagraph().Append(purchase.login);
                table.Rows[i].Cells[1].InsertParagraph().Append(purchase.date.ToString("dd-MM-yyyy hh:mm"));
                table.Rows[i].Cells[2].InsertParagraph().Append(purchase.Product.name);
                table.Rows[i].Cells[3].InsertParagraph().Append(currency(purchase.Product.cost_with_margin));
                i++;
            }

            doc.InsertTable(table);
        }
    }
}