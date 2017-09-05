using System;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace QuartzScheduler.Learn.Dao
{
    public class ExcelHelper : IDisposable
    {
        private readonly string fileName;
        private IWorkbook workbook;
        private FileStream fileStream;
        private bool disposed;

        public ExcelHelper(string fileName)
        {
            this.fileName = fileName;
            disposed = false;
        }

        private void CheckFile()
        {
            FileInfo info = new FileInfo(fileName);
            // 判断是否是Excel文件
            if (info.Extension.ToLower().Equals(".xlsx")) // 2007 以上的版本
            {
                workbook = new XSSFWorkbook();
            }
            else if (info.Extension.ToLower().Equals(".xls")) // 2003 版本
            {
                workbook = new HSSFWorkbook();
            }
        }

        /// <summary>
        /// 将一个DataSet数据导出到一张Excel中
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isColumnWritten"></param>
        public void DataSetToExcel(DataSet data, bool isColumnWritten)
        {
            int i = 0;
            foreach (DataTable dt in data.Tables)
            {
                DataTableToExcel(dt, string.Format("Sheet{0}", i), isColumnWritten);
                i++;
            }
        }

        /// <summary>
        /// 将DataTable中的数据转换为Excel
        /// </summary>
        /// <param name="data">DataTable数据集</param>
        /// <param name="sheetName">表格名称</param>
        /// <param name="isColumnWritten">是否需要书写列头</param>
        /// <returns></returns>
        public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten)
        {
            using (fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                CheckFile();
                try
                {
                    ISheet sheet;
                    if (workbook != null)
                    {
                        string currentSheetName = string.IsNullOrEmpty(data.TableName) ? data.TableName : sheetName;
                        sheet = workbook.CreateSheet(currentSheetName);
                    }
                    else
                    {
                        return -1;
                    }

                    int count;
                    if (isColumnWritten)
                    {
                        // 书写Excel的列头
                        IRow row = sheet.CreateRow(0);
                        for (int j = 0; j < data.Columns.Count; ++j)
                        {
                            row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                        }
                        count = 1;
                    }
                    else
                    {
                        count = 0;
                    }

                    for (int i = 0; i < data.Rows.Count; ++i)
                    {
                        IRow row = sheet.CreateRow(count);
                        for (int j = 0; j < data.Columns.Count; ++j)
                        {
                            row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                        }
                        ++count;
                    }
                    workbook.Write(fileStream);
                    return count;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 将Excel转换为DataTable
        /// </summary>
        /// <param name="sheetName"></param>
        /// <param name="isFirstRowColumn"></param>
        /// <returns></returns>
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {
            DataSet dataSet = ExcelToDataSet(isFirstRowColumn);
            foreach (DataTable dt in dataSet.Tables)
            {
                if (dt.TableName == sheetName)
                {
                    return dt;
                }
            }
            return null;
        }

        /// <summary>
        /// 将Excel转换为DataSet集合
        /// </summary>
        /// <param name="isFirstRowColumn"></param>
        /// <returns></returns>
        public DataSet ExcelToDataSet(bool isFirstRowColumn)
        {
            try
            {
                DataSet dataSet = new DataSet();
                using (fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    CheckFile();
                    int sheetCount = workbook.NumberOfSheets;
                    for (int index = 0; index < sheetCount; index++)
                    {
                        ISheet sheet = workbook.GetSheetAt(index);
                        DataTable data = new DataTable(sheet.SheetName);

                        IRow firstRow = sheet.GetRow(0);
                        int cellCount = firstRow.LastCellNum;

                        int startRow;
                        if (isFirstRowColumn)
                        {
                            for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                            {
                                ICell cell = firstRow.GetCell(i);
                                if (null != cell)
                                {
                                    string cellValue = cell.StringCellValue;
                                    if (null != cellValue)
                                    {
                                        DataColumn column = new DataColumn(cellValue);
                                        data.Columns.Add(column);
                                    }
                                }
                            }

                            startRow = sheet.FirstRowNum + 1;
                        }
                        else
                        {
                            startRow = sheet.FirstRowNum;
                        }

                        int rowCount = sheet.LastRowNum;
                        for (int i = startRow; i <= rowCount; ++i)
                        {
                            IRow row = sheet.GetRow(i);
                            if (null == row)
                            {
                                continue;
                            }

                            DataRow dataRow = data.NewRow();
                            for (int j = row.FirstCellNum; j < cellCount; ++j)
                            {
                                if (row.GetCell(j) != null)
                                {
                                    dataRow[j] = row.GetCell(j).ToString();
                                }
                            }
                            data.Rows.Add(dataRow);
                        }
                        dataSet.Tables.Add(data);
                    }
                    return dataSet;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    /// <summary>
        /// 对象释放
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (fileStream != null)
                    {
                        fileStream.Close();
                    }
                }
                fileStream = null;
                disposed = true;
            }
        }
    }
}
