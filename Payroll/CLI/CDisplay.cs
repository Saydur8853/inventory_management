using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace NGPayroll
{
	public static class CDisplay
    {
        #region "Search Text Show in List Box"
        public static void UNIT_Name_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            string strSubText = "";
            CPresent.listBoxForWhom = "UNIT_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            if (CConfig.MASTER_TAG != 0) strSubText = " AND COMPANY_ID='" + CConfig.MASTER_TAG+"'";
            string query = "SELECT UNIT_ID,UNIT_NAME FROM UNIT WHERE UPPER(UNIT_NAME) LIKE UPPER('%" + searchKey + "%')" + strSubText + " ORDER BY UNIT_NAME";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void COMPANY_NAME_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "COMPANY_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "SELECT COMPANY_ID,COMPANY_NAME FROM TB_COMPANY WHERE UPPER(COMPANY_NAME) LIKE UPPER('" + searchKey + "%') ORDER BY COMPANY_NAME";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void DESIGNATION_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "DESIGNATION_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "SELECT DESIGNATION_ID,DESIGNATION_NAME FROM DESIGNATION WHERE UPPER(DESIGNATION_NAME) LIKE UPPER('" + searchKey + "%') ORDER BY DESIGNATION_NAME";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void InsuranceCompany_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "INSURANCE_COMPANY_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select INSURANCE_COMPANY_ID,INSURANCE_COMPANY_NAME from INSURANCE_COMPANY where upper(INSURANCE_COMPANY_NAME) like upper('" + searchKey + "%') order by INSURANCE_COMPANY_NAME";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void PresentAddress_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "PRESENT_ADDRESS";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select FEATURE_ID,PARAMETER from FEATURE where ATTRIBUTE ='PRESENT ADDRESS' and upper(PARAMETER) like upper('%" + searchKey + "%') order by PARAMETER";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void EducationLevel_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "EDUCATION";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select FEATURE_ID,PARAMETER from FEATURE where ATTRIBUTE ='EDUCATION' and upper(PARAMETER) like upper('" + searchKey + "%') order by PARAMETER";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void employeeName_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "EMP_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "SELECT DISTINCT '1' AS EMP_ID,EMP_NAME FROM EMP_OFFICIAL WHERE UPPER(EMP_NAME) LIKE UPPER('" + searchKey + "%') ORDER BY EMP_NAME";
            CPresent.CommonListBox(myListBox, query);
        }
        public static void EmployeeName_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "EMP_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "SELECT DISTINCT EMP_ID,EMP_NAME FROM EMP_OFFICIAL WHERE UPPER(EMP_NAME) LIKE UPPER('" + searchKey + "%') ORDER BY EMP_NAME";
            CPresent.CommonListBox(myListBox, query);
        }
        public static void presentVillageName_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "PRESENT_VILL";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select distinct '1' as EMP_ID,PRESENT_VILL from EMP_PERSONAL where upper(PRESENT_VILL) like upper('" + searchKey + "%') order by PRESENT_VILL";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void presentPoliceStationName_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "PRESENT_PS";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select distinct '1' as EMP_ID,PRESENT_PS from EMP_PERSONAL where upper(PRESENT_PS) like upper('" + searchKey + "%') order by PRESENT_PS";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void presentDistrictName_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "PRESENT_DIST";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select distinct '1' as EMP_ID,PRESENT_DIST from EMP_PERSONAL where upper(PRESENT_DIST) like upper('" + searchKey + "%') order by PRESENT_DIST";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void parmanentPoliceStationName_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "PARMANENT_PS";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select distinct '1' as EMP_ID,PARMANENT_PS from EMP_PERSONAL where upper(PARMANENT_PS) like upper('" + searchKey + "%') order by PARMANENT_PS";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void parmanentVillagetName_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "PARMANENT_VILL";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select distinct '1' as EMP_ID,PARMANENT_VILL from EMP_PERSONAL where upper(PARMANENT_VILL) like upper('" + searchKey + "%') order by PARMANENT_VILL";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void parmanentDistrictName_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "PARMANENT_DIST";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select distinct '1' as EMP_ID,PARMANENT_DIST from EMP_PERSONAL where upper(PARMANENT_DIST) like upper('" + searchKey + "%') order by PARMANENT_DIST";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void EMP_CATEGORY_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "EMP_CATEGORY_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select EMP_CATEGORY_ID,EMP_CATEGORY_NAME from EMP_CATEGORY where upper(EMP_CATEGORY_NAME) like upper('" + searchKey + "%') order by EMP_CATEGORY_NAME";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void LINE_NAME_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            if (CConfig.UNIT_TAG != 0)
            {
                string text = " AND UNIT_ID='" + CConfig.UNIT_TAG + "'";
                CPresent.listBoxForWhom = "LINE_NAME";
                CPresent.showListBox(myTextBox, myListBox);
                string query = "SELECT LINE_ID,LINE_NAME FROM LINE WHERE UPPER(LINE_NAME) LIKE UPPER('" + searchKey + "%')" + text + " ORDER BY LINE_NAME";
                CPresent.CommonListBox(myListBox, query);
            }
        }
        public static void DepartmentName_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "DEPARTMENT_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM DEPARTMENT WHERE UPPER(DEPARTMENT_NAME) LIKE UPPER('" + searchKey + "%') ORDER BY DEPARTMENT_NAME";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void SECTION_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            if (CConfig.UNIT_TAG != 0)
            {
                string text = " AND UNIT_ID ='" + CConfig.UNIT_TAG + "'";
                CPresent.listBoxForWhom = "SECTION_NAME";
                CPresent.showListBox(myTextBox, myListBox);
                string query = "SELECT SECTION_ID,SECTION_NAME FROM SECTION WHERE UPPER(SECTION_NAME) LIKE UPPER('" + searchKey + "%')" + text + " ORDER BY SECTION_NAME";
                CPresent.CommonListBox(myListBox, query);
            }
        }

        public static void transportStandIntoListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "STAND_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select STAND_ID,STAND_NAME from TRANSPORT_STAND where upper(STAND_NAME) like upper('" + searchKey + "%') order by STAND_NAME";
            CPresent.CommonListBox(myListBox, query);
        }
        
        public static void ProgramName_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "program_name";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select program_id,program_name from program where upper(program_name) like upper('" + searchKey + "%') order by program_name";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void QUATER_BUILDING_NAME_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "QUATER_BUILDING_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select QUATER_BUILDING_ID,QUATER_BUILDING_NAME from QUATER_BUILDING where upper(QUATER_BUILDING_NAME) like upper('" + searchKey + "%') order by QUATER_BUILDING_NAME";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void QUATER_FLOOR_NAME_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "QUATER_FLOOR_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select QUATER_FLOOR_ID,QUATER_FLOOR_NAME from QUATER_FLOOR where upper(QUATER_FLOOR_NAME) like upper('" + searchKey + "%') order by QUATER_FLOOR_NAME";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void Shift_Info_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "SHIFT_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "SELECT SHIFT_ID,SHIFT_NAME FROM SHIFT_INFO WHERE UPPER(SHIFT_NAME) LIKE UPPER('" + searchKey + "%') ORDER BY SHIFT_NAME";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void SalaryRule_Info_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "RULE_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "SELECT RULE_ID,RULE_NAME FROM SALARY_RULE_INFO WHERE UPPER(RULE_NAME) LIKE UPPER('" + searchKey + "%') ORDER BY RULE_NAME";
            CPresent.CommonListBox(myListBox, query);
        }        

        public static void Supplier_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "SUP_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select SUP_CODE,SUP_NAME from SUPPLIER_TBL where upper(SUP_NAME) like upper('" + searchKey + "%') order by SUP_NAME";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void G_ITEM_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "G_ITEM_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select G_ITEM_CODE,G_ITEM_NAME from G_ITEM_TBL where upper(G_ITEM_NAME) like upper('" + searchKey + "%') order by G_ITEM_NAME";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void ITEM_GROUP__Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "ITEM_GRP_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select ITEM_GRP_CODE,ITEM_GRP_NAME from ITEM_GRP_TBL where upper(ITEM_GRP_NAME) like upper('" + searchKey + "%') order by ITEM_GRP_NAME";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void Voucher_No_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "voucher_no";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select sales_id,voucher_no from sales where upper(voucher_no) like upper('" + searchKey + "%') order by voucher_no";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void doctor_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "name";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select * from doctor where upper(name) like upper('" + searchKey + "%') order by name";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void pharmacy_item_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "itemnam";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select PhID, itemnam from Pharmacy where upper(itemnam) like upper('" + searchKey + "%') order by itemnam ";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void member_id_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "member_id";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select * from member where upper(member_id) like upper('" + searchKey + "%') order by member_id";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void LedgerName_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "LEDGER_NAME";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select LEDGER_ID, LEDGER_NAME from LEDGER where upper(LEDGER_NAME) like upper('" + searchKey + "%') order by LEDGER_NAME";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void employeeCode_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "EMP_CODE";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select distinct '1' as EMP_ID,EMP_CODE from EMP_OFFICIAL where upper(EMP_CODE) like upper('" + searchKey + "%') order by EMP_CODE";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void proximitycard_Into_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
        {
            CPresent.listBoxForWhom = "EMP_PROXIMITY";
            CPresent.showListBox(myTextBox, myListBox);
            string query = "select distinct '1' as EMP_ID, PROXIMITY_NO from EMP_OFFICIAL where upper(PROXIMITY_NO) like upper('" + searchKey + "%') order by PROXIMITY_NO";
            CPresent.CommonListBox(myListBox, query);
        }

        public static void ParmanentPostOffcie_Info_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
		{
			CPresent.listBoxForWhom = "PARMANENT_POSTOFFICE";
			CPresent.showListBox(myTextBox, myListBox);
            string query = "select distinct '1' as EMP_ID, PARMANENT_VILL from EMP_PERSONAL where upper(PARMANENT_VILL) like upper('" + searchKey + "%') order by PARMANENT_VILL";
			CPresent.CommonListBox(myListBox, query);
		}

        public static void presentPostOffcie_Info_ListBox(TextBox myTextBox, ListBox myListBox, string searchKey)
		{
			CPresent.listBoxForWhom = "PRESENT_POSTOFFICE";
			CPresent.showListBox(myTextBox, myListBox);
            string query = "select distinct '1' as EMP_ID,PRESENT_HOUSE from EMP_PERSONAL where upper(PRESENT_HOUSE) like upper('" + searchKey + "%') order by PRESENT_HOUSE";
			CPresent.CommonListBox(myListBox, query);
		}

        #endregion

        #region "Image Converter"

        public static byte[] GetBytesFromSource(string sFilename)
        {
            if (File.Exists(sFilename))
            {
                return File.ReadAllBytes(sFilename);
            }
            return null;
        }

        public static byte[] ResizeImageFile(byte[] imageFile, Size newSize, ImageFormat imageFormat)
        {
            using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
            {
                Size newSizeTemp = CalculateDimensions(oldImage.Size, newSize);
                using (Bitmap newImage = new Bitmap(newSizeTemp.Width, newSizeTemp.Height, PixelFormat.Format24bppRgb))
                {
                    using (Graphics canvas = Graphics.FromImage(newImage))
                    {
                        canvas.SmoothingMode = SmoothingMode.AntiAlias;
                        canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSizeTemp));
                        MemoryStream m = new MemoryStream();
                        newImage.Save(m, imageFormat);
                        return m.GetBuffer();
                    }
                }
            }
        }

        private static Size CalculateDimensions(Size oldSize, Size newSize)
        {
            Size newSizeTemp = new Size();
            if (oldSize.Height > oldSize.Width)
            {
                newSizeTemp.Width = (int)(oldSize.Width * ((float)newSize.Height / (float)oldSize.Height));
                newSizeTemp.Height = newSize.Height;
            }
            else
            {
                newSizeTemp.Width = newSize.Width;
                newSizeTemp.Height = (int)(oldSize.Height * ((float)newSize.Width / (float)oldSize.Width));
            }
            return newSizeTemp;
        }

        public static MemoryStream GetMemoryStream(byte[] byteBLOBData)
        {
            return new MemoryStream(byteBLOBData);
        }

        public static Stream GetMemoryStream(string p)
        {
            throw new NotImplementedException();
        }

        #endregion
	}
}

