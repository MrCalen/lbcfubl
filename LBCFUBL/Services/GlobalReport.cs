using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using Novacode;
using System.Globalization;

namespace LBCFUBL.Services
{
    public class GlobalReport
    {
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public string MimeType { get; private set; } = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

        private GlobalReport()
        {
            string dir = @"C:\ProgramData\LBCFUBL\Reports";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            FileName = "global.docx";
            FilePath = dir + @"\" + FileName;
        }

        private static void setTableStyle(Novacode.Table table)
        {
            table.Design = TableDesign.LightGridAccent1;
            table.AutoFit = AutoFit.ColumnWidth;
        }

        private IFormatProvider GetCurrencyFormat()
        {
            return CultureInfo.CreateSpecificCulture("fr-FR");
        }

        public static GlobalReport CreateReport()
        {
            GlobalReport report = new GlobalReport();
            
            using (DocX doc = DocX.Create(report.FilePath))
            {
                report.Fill(doc);
                doc.Save();
            }

            return report;
        }

        private void Fill(DocX doc)
        {
            doc.InsertParagraph().Heading(HeadingType.Heading1).Append("Laboratoire des assistants - Raport des comptes");

            doc.InsertSection();
            doc.InsertParagraph().Heading(HeadingType.Heading2).Append("Information générales");
            FillGlobalInfos(doc);

            doc.InsertSection();
            doc.InsertParagraph().Heading(HeadingType.Heading2).Append("Dettes des assistants");
            FillUsersInfos(doc);

            doc.InsertSection();
            doc.InsertParagraph().Heading(HeadingType.Heading2).Append("Accomptes");
            FillAccounts(doc);

            doc.InsertSection();
            doc.InsertParagraph().Heading(HeadingType.Heading2).Append("Détails d'achats");
            FillPurchases(doc);
        }

        private double GetTotalAccounts()
        {
            return Helper.GetAccountClient().GetAccounts().Sum(x => x.argent);
        }

        private double GetTotalPurchases()
        {
            return Helper.GetPurchaseClient().GetPurchases().Sum(x => x.Product.cost_without_margin);
        }

        private void FillGlobalInfos(DocX doc)
        {
            doc.InsertParagraph()
                .AppendLine("Total accomptes : " + GetTotalAccounts().ToString("C", GetCurrencyFormat()))
                .AppendLine("Total dépenses : " + GetTotalPurchases().ToString("C", GetCurrencyFormat()))
                .AppendLine("Balance : " + (GetTotalAccounts() - GetTotalPurchases()).ToString("C", GetCurrencyFormat()));
        }

        private void FillUsersInfos(DocX doc)
        {
            LBCFUBL_WCF.DBO.User[] users = Helper.GetUserClient().GetUsers();
            Novacode.Table table = doc.AddTable(users.Count() + 1, 4);
            setTableStyle(table);

            table.Rows[0].Cells[0].InsertParagraph().Bold().Append("Login");
            table.Rows[0].Cells[1].InsertParagraph().Bold().Append("Accompte");
            table.Rows[0].Cells[2].InsertParagraph().Bold().Append("Dette");
            table.Rows[0].Cells[3].InsertParagraph().Bold().Append("Balance");

            int i = 1;
            foreach (LBCFUBL_WCF.DBO.User user in users)
            {
                double totalAccounts = Helper
                    .GetAccountClient()
                    .GetAccountsForLogin(user.login)
                    .Sum(x => x.argent);

                double totalPurchases = Helper
                    .GetPurchaseClient()
                    .GetPurchasesForLogin(user.login)
                    .Sum(x => x.Product.cost_with_margin);

                table.Rows[i].Cells[0].InsertParagraph().Append(user.login);
                table.Rows[i].Cells[1].InsertParagraph().Append(totalAccounts.ToString("C", GetCurrencyFormat()));
                table.Rows[i].Cells[2].InsertParagraph().Append(totalPurchases.ToString("C", GetCurrencyFormat()));
                table.Rows[i].Cells[3].InsertParagraph().Append((totalAccounts - totalPurchases).ToString("C", GetCurrencyFormat()));

                i++;
            }

            doc.InsertTable(table);
        }

        private void FillAccounts(DocX doc)
        {
            LBCFUBL_WCF.DBO.Account[] accounts = Helper.GetAccountClient().GetAccounts();
            Novacode.Table table = doc.AddTable(accounts.Count() + 1, 3);
            setTableStyle(table);

            table.Rows[0].Cells[0].InsertParagraph().Bold().Append("Login");
            table.Rows[0].Cells[1].InsertParagraph().Bold().Append("Date");
            table.Rows[0].Cells[2].InsertParagraph().Bold().Append("Argent");

            int i = 1;
            foreach (LBCFUBL_WCF.DBO.Account account in accounts)
            {
                table.Rows[i].Cells[0].InsertParagraph().Append(account.login);
                table.Rows[i].Cells[1].InsertParagraph().Append(account.date.ToString("dd-MM-yyyy hh:mm"));
                table.Rows[i].Cells[2].InsertParagraph().Append(account.argent.ToString("C", GetCurrencyFormat()));
                i++;
            }

            doc.InsertTable(table);
        }

        private void FillPurchases(DocX doc)
        {
            LBCFUBL_WCF.DBO.Purchase[] purchases = Helper.GetPurchaseClient().GetPurchases();
            Novacode.Table table = doc.AddTable(purchases.Count() + 1, 4);
            setTableStyle(table);

            table.Rows[0].Cells[0].InsertParagraph().Bold().Append("Login");
            table.Rows[0].Cells[1].InsertParagraph().Bold().Append("Date");
            table.Rows[0].Cells[2].InsertParagraph().Bold().Append("Produit");
            table.Rows[0].Cells[3].InsertParagraph().Bold().Append("Prix");

            int i = 1;
            foreach (LBCFUBL_WCF.DBO.Purchase purchase in purchases)
            {
                table.Rows[i].Cells[0].InsertParagraph().Append(purchase.login);
                table.Rows[i].Cells[1].InsertParagraph().Append(purchase.date.ToString("dd-MM-yyyy hh:mm"));
                table.Rows[i].Cells[2].InsertParagraph().Append(purchase.Product.name);
                table.Rows[i].Cells[3].InsertParagraph().Append(purchase.Product.cost_with_margin.ToString("C", GetCurrencyFormat()));
                i++;
            }

            doc.InsertTable(table);
        }
    }
}