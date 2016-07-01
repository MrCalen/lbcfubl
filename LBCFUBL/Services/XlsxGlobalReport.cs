using System;
using System.IO;
using System.Data;
using System.Drawing;
using OfficeOpenXml;
using System.Collections.Generic;
using OfficeOpenXml.Style;
using System.Linq;

namespace LBCFUBL.Services
{
    public class XlsxGlobalReport : Report
    {
        protected XlsxGlobalReport(DateTime from, DateTime to) 
            : base("global", "xlsx", from, to)
        {
        }

        public static XlsxGlobalReport CreateReport(DateTime from, DateTime to)
        {
            XlsxGlobalReport report = new XlsxGlobalReport(from, to);

            FileInfo file = new FileInfo(report.FilePath);
            file.Delete();

            using (ExcelPackage xlsx = new ExcelPackage(file))
            {
                report.Fill(xlsx);
                xlsx.Save();
            }
            
            return report;
        }

        private void Fill(ExcelPackage xlsx)
        {
            InsertWorksheet(xlsx, GetUsersInfos(), "Dettes", "D");
            InsertWorksheet(xlsx, GetAccounts(), "Accomptes", "C");
            InsertWorksheet(xlsx, GetPurchases(), "Achats", "D");
        }

        private void InsertWorksheet(ExcelPackage xlsx, DataTable table, string name, string l)
        {
            ExcelWorksheet ws = xlsx.Workbook.Worksheets.Add(name);
            ws.Cells["A1"].LoadFromDataTable(table, true);

            using (ExcelRange rng = ws.Cells["A1:" + l + "1"])
            {
                rng.Style.Font.Bold = true;
                rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));
                rng.Style.Font.Color.SetColor(Color.White);
            }
        }

        private static DataTable MakeDataTable(IDictionary<string, string> pairs)
        {
            DataTable table = new DataTable();

            foreach (KeyValuePair<string, string> pair in pairs)
            {
                table.Columns.Add(new DataColumn()
                {
                    ColumnName = pair.Key,
                    Caption = pair.Value,
                });
            }

            return table;
        }

        private DataTable GetUsersInfos()
        {
            IEnumerable<LBCFUBL_WCF.DBO.User> users = Helper
                .GetUserClient()
                .GetUsers()
                .OrderBy(x => x.login);

            DataTable table = MakeDataTable(new Dictionary<string, string>()
            {
                { "login", "Login" },
                { "account", "Accompte" },
                { "due", "Dette" },
                { "balance", "Balance" },
            });

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);

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

                DataRow row = table.NewRow();

                row["login"] = user.login;
                row["account"] = Math.Round(totalAccount, 2);
                row["due"] = Math.Round(totalPurchases, 2);
                row["balance"] = Math.Round(totalAccount - totalPurchases, 2);

                table.Rows.Add(row);
            }

            return table;
        }

        private DataTable GetAccounts()
        {
            IEnumerable<LBCFUBL_WCF.DBO.Account> accounts = Helper
                .GetAccountClient()
                .GetAccounts()
                .OrderBy(x => x.login)
                .Where(x => x.date >= from && x.date <= to);

            DataTable table = MakeDataTable(new Dictionary<string, string>() {
                { "login", "Login" },
                { "date", "Date" },
                { "argent", "Argent" },
            });

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);

            foreach (LBCFUBL_WCF.DBO.Account account in accounts)
            {
                DataRow row = table.NewRow();

                row["login"] = account.login;
                row["date"] = account.date;
                row["argent"] = Math.Round(account.argent, 2);

                table.Rows.Add(row);
            }

            return table;
        }

        private DataTable GetPurchases()
        {
            IEnumerable<LBCFUBL_WCF.DBO.Purchase> purchases = Helper
                .GetPurchaseClient()
                .GetPurchases()
                .OrderBy(x => x.date)
                .OrderBy(x => x.login)
                .ThenBy(x => x.Product.name)
                .Where(x => x.date >= from && x.date <= to);

            DataTable table = MakeDataTable(new Dictionary<string, string>() {
                { "login", "Login" },
                { "date", "Date" },
                { "product", "Product" },
                { "price", "Prix" },
            });

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(table);

            foreach (LBCFUBL_WCF.DBO.Purchase purchase in purchases)
            {
                DataRow row = table.NewRow();

                row["login"] = purchase.login;
                row["date"] = purchase.date.ToString("dd-MM-yyyy hh:mm");
                row["product"] = purchase.Product.name;
                row["price"] = Math.Round(purchase.Product.cost_with_margin, 2);

                table.Rows.Add(row);
            }

            return table;
        }
    }
}