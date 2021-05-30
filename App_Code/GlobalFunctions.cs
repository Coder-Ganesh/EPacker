using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ePacker1.App_Code
{
    class GlobalFunctions
    {

        public static void AddPleaseSelect(ref DataTable dt)
        {
            try
            {
                if (dt.Columns.Count > 1)
                {
                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "Please Select";
                    dt.Rows.InsertAt(row, 0);
                }
                else if (dt.Columns.Count == 1)
                {
                    DataRow row = dt.NewRow();
                    //row[0] = 0;
                    row[0] = "Please Select";
                    dt.Rows.InsertAt(row, 0);
                }
            }
            catch (Exception ex) {}
        }

        public static void AddYesNoOptions(ref DataTable dt)
        {
            try
            {
                dt.Columns.Add("Options");
                DataRow dr = dt.NewRow();
                dr["Options"] = "Please Select";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "Yes";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "No";
                dt.Rows.Add(dr);
            }
            catch (Exception ex)
            {
            }
        }

        public static void AddBloodGrpOptions(ref DataTable dt)
        {
            try
            {
                dt.Columns.Add("Options");
                DataRow dr = dt.NewRow();
                dr["Options"] = "Please Select";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "AB+";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "AB-";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "O-";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "O+";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "A-";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "A+";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "B-";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "B+";
                dt.Rows.Add(dr);                
            }
            catch (Exception ex)
            {
            }
        }

        public static void AddDivisionFactorsForPlate(ref DataTable dt)
        {
            try
            {
                dt.Columns.Add("Options");
                DataRow dr = dt.NewRow();
                dr["Options"] = "Please Select";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "1000";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "2000";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "3000";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "4000";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "5000";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "6000";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "7000";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "8000";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "9000";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "10000";
                dt.Rows.Add(dr);
            }
            catch (Exception ex)
            {
            }
        }

        public bool IsDecimalFormat(string input)
        {
            Decimal dummy;
            return Decimal.TryParse(input, out dummy);
        }

        public static void AddSiCategoryOptions(ref DataTable dt)
        {
            try
            {
                dt.Columns.Add("Options");
                DataRow dr = dt.NewRow();
                dr["Options"] = "Please Select";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "Excisable Item";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "57F4 Item";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "Non- Excisable Item";
                dt.Rows.Add(dr);
            }
            catch (Exception ex)
            {
            }
        }

        public static void AddLaminationTypesOptions(ref DataTable dt)
        {
            try
            {
                dt.Columns.Add("Options");
                DataRow dr = dt.NewRow();
                dr["Options"] = "Please Select";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "PVC";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "BOPP";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "LDPE";
                dt.Rows.Add(dr);
            }
            catch (Exception ex)
            {
            }
        }

        public static void AddLaminationThickness(ref DataTable dt)
        {
            try
            {
                dt.Columns.Add("Options");
                DataRow dr = dt.NewRow();
                dr["Options"] = "Please Select";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "8";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "9";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "10";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "11";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "12";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "13";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "14";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "15";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "16";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "17";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "18";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "19";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "20";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "21";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "22";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "23";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "24";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "25";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "26";
                dr = dt.NewRow();
                dr = dt.NewRow();
                dr["Options"] = "27";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "28";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "29";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "30";
                dt.Rows.Add(dr);
                dt.Rows.Add(dr);
            }
            catch (Exception ex)
            {
            }
        }

        public static void GetPlySheets(ref DataTable dt)
        {
            try
            {
                dt.Columns.Add("Options");
                DataRow dr = dt.NewRow();
                dr["Options"] = "Please Select";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "1";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "2";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "3";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "5";
                dt.Rows.Add(dr);               
                dr = dt.NewRow();
                dr["Options"] = "7";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "9";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "11";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "13";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Options"] = "15";
                dt.Rows.Add(dr);
            }
            catch (Exception)
            {
                
            }
        }

    }
}
