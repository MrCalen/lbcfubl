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
    public class DocXUserReport
    {
        private LBCFUBL_WCF.DBO.User user;

        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public string MimeType { get; private set; } = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

        private DocXUserReport(string login)
        {
            if (login == null)
                throw new ArgumentNullException("user");

            string dir = @"C:\ProgramData\LBCFUBL\Reports";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            user = Helper.GetUserClient().GetUserFromLogin(login);
            if (user == null)
                throw new ArgumentException("User fo login `" + login + "` not found");

            FileName = user.login + ".docx";
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

        public static DocXUserReport CreateReport(string login)
        {
            DocXUserReport report = new DocXUserReport(login);
            
            using (DocX doc = DocX.Create(report.FilePath))
            {
                report.Fill(doc);
                doc.Save();
            }

            return report;
        }

        private double GetTotalAccounts()
        {
            return Helper
                .GetAccountClient()
                .GetAccountsForLogin(user.login)
                .Sum(x => x.argent);
        }

        private double GetTotalPurchases()
        {
            return Helper
                .GetPurchaseClient()
                .GetPurchasesForLogin(user.login)
                .Sum(x => x.Product.cost_with_margin);
        }

        private void Fill(DocX doc)
        {
            doc.InsertParagraph().Heading(HeadingType.Heading1).Append(user.login);

            doc.InsertSection();
            doc.InsertParagraph().Heading(HeadingType.Heading2).Append("Information generales");
            FillUserInfos(doc);

            doc.InsertSection();
            doc.InsertParagraph().Heading(HeadingType.Heading2).Append("Accomptes");
            FillAccounts(doc);

            doc.InsertSection();
            doc.InsertParagraph().Heading(HeadingType.Heading2).Append("Achats");
            FillPurchases(doc);
        }

        private void FillUserInfos(DocX doc)
        {
            doc.InsertParagraph()
                .AppendLine("Login : " + user.login)
                .AppendLine("Role : " + LBCFUBL_WCF.DataAccess.User.RoleFromInt(user.role))
                .AppendLine("Bloqué : " + (user.is_blocked == 1 ? "Oui" : "Non"))
                .AppendLine("Total accomptes : " + GetTotalAccounts().ToString("C", GetCurrencyFormat()))
                .AppendLine("Total dépenses : " + GetTotalPurchases().ToString("C", GetCurrencyFormat()))
                .AppendLine("Balance : " + (GetTotalAccounts() - GetTotalPurchases()).ToString("C", GetCurrencyFormat()));
        }

        private void FillAccounts(DocX doc)
        {
            LBCFUBL_WCF.DBO.Account[] accounts = Helper.GetAccountClient().GetAccountsForLogin(user.login);
            Novacode.Table table = doc.AddTable(accounts.Count() + 1, 2);
            setTableStyle(table);

            table.Rows[0].Cells[0].InsertParagraph().Bold().Append("Date");
            table.Rows[0].Cells[1].InsertParagraph().Bold().Append("Argent");

            int i = 1;
            foreach (LBCFUBL_WCF.DBO.Account account in accounts)
            {
                table.Rows[i].Cells[0].InsertParagraph().Append(account.date.ToString("dd-MM-yyyy hh:mm"));
                table.Rows[i].Cells[1].InsertParagraph().Append(account.argent.ToString("C", GetCurrencyFormat()));
                i++;
            }
            
            doc.InsertTable(table);
        }

        private void FillPurchases(DocX doc)
        {
            LBCFUBL_WCF.DBO.Purchase[] purchases = Helper.GetPurchaseClient().GetPurchasesForLogin(user.login);
            Novacode.Table table = doc.AddTable(purchases.Count() + 1, 3);
            setTableStyle(table);

            table.Rows[0].Cells[0].InsertParagraph().Bold().Append("Date");
            table.Rows[0].Cells[1].InsertParagraph().Bold().Append("Produit");
            table.Rows[0].Cells[2].InsertParagraph().Bold().Append("Prix");

            int i = 1;
            foreach (LBCFUBL_WCF.DBO.Purchase purchase in purchases)
            {
                table.Rows[i].Cells[0].InsertParagraph().Append(purchase.date.ToString("dd-MM-yyyy hh:mm"));
                table.Rows[i].Cells[1].InsertParagraph().Append(purchase.Product.name);
                table.Rows[i].Cells[2].InsertParagraph().Append(purchase.Product.cost_with_margin.ToString("C", GetCurrencyFormat()));
                i++;
            }

            doc.InsertTable(table);
        }
    }
}