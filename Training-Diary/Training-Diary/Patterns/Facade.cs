using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace Training_Diary
{
    class Facade
    {
        public UserTraining mySp { get; set; }
        public Facade(UserTraining m)
        {
            mySp = m;
        }
        public void DoIt()
        {
            GetExcel excel = new GetExcel();
            ExportDataToExcel exdata = new ExportDataToExcel();
            exdata.Metod(mySp, excel.workSheet);
            CloseExcel closeex = new CloseExcel(excel.exApp, excel.workSheet);
        }
    }
    public class GetExcel
    {
        public Excel.Application exApp;
        public Excel.Worksheet workSheet;
        public GetExcel()
        {
            exApp = new Excel.Application();
            exApp.Visible = true;
            exApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)exApp.ActiveSheet;
          

        }
    }
    public class CloseExcel
    {
        string pathToXml;
        public CloseExcel(Excel.Application exApp, Excel.Worksheet workSheet)
        {

            pathToXml = Environment.CurrentDirectory + "\\" + "MyFile2.xls";
            workSheet.SaveAs(pathToXml);
            exApp.Quit();
        }
    }
    public class ExportDataToExcel
    {
        
        public void Metod(UserTraining m, Excel.Worksheet workSheet)
        {
            int i = 1;
            foreach (var a in m.Exercises)
            {
               i= a.GetTrData(workSheet,i);

            }
        }
    }
    public interface IExcelStrategy
    {
        void GetTrData(Excel.Worksheet workSheet, Excel.Range oRng, int i);
    }
    //public class ExportKardStrategy : KardExercises, IExcelStrategy
    //{
    //    public void GetTrData(Excel.Worksheet workSheet, Excel.Range oRng, int i)
    //    {

    //        workSheet.Cells[i, 1] = "Type";
    //        workSheet.Cells[i, 2] = "Name";
    //        workSheet.Cells[i, 3] = "Time";
    //        i++;
    //        foreach (var a in this)
    //        {
    //            workSheet.Cells[i, 1] = a.GetType();
    //            workSheet.Cells[i, 2] = a.ExName;
    //            workSheet.Cells[i, 3] = a.Duration;
    //        }
    //    }
    //}
    //public class ExportStrenghtStrategy : StExercises, IExcelStrategy
    //{
    //    public void GetTrData(Excel.Worksheet workSheet,Excel.Range oRng, int i)

    //    {
    //        //workSheet.Cells[i, 1] = "Type";
    //        workSheet.Cells[i, 1] = "Name";
    //        workSheet.Cells[i, 2] = "PassNumber";
    //        workSheet.Cells[i, 3] = "Reiteration";
    //        workSheet.Cells[i, 4] = "Weight";
    //        i++;
    //        foreach (var a in this)
    //        {
    //            oRng = workSheet.Range[workSheet.Cells[i , 1], workSheet.Cells[(i + a.ExPassNumber.Count), 1]];
    //            oRng.Merge();
    //            oRng.Value = a.ExName;
    //            foreach (var b in a.ExPassNumber)
    //            {

    //               // workSheet.Cells[i, 1] = b.GetType();
    //                workSheet.Cells[i , 2] = b.PassNumberName;
    //                workSheet.Cells[i , 3] = b.Reiteration;
    //                workSheet.Cells[i , 4] = b.Weight;
    //                i++;
    //            }
    //        }
    //    }
    
}
