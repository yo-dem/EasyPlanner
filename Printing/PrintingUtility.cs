using EasyPlanner.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using System.Diagnostics;
using System.Globalization;

namespace EasyPlanner.Printing
{
    internal struct PrintingUtility
    {
        public static void CreatePDF(DataTable dt, string destinationPath)
        {
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationPath, FileMode.Create));
            document.Open();

            MakeHeader(document, dt);
            MakeContent(document, dt);
            MakeSum(document, dt);

            document.Close();
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(destinationPath)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        static void MakeHeader(Document doc, DataTable dt)
        {
            // LOGO SECTION
            iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(Properties.Resources.CapelliAndManieBW, System.Drawing.Imaging.ImageFormat.Png);
            pic.ScaleToFit(300f, 100f);
            pic.SetAbsolutePosition(58, 720);
            doc.Add(pic);
            //----------------------------------------------------------------------------------------------------

            // SPACER
            PdfPTable tableHeaderSpacer = new PdfPTable(1);
            PdfPCell cellHeaderEmpty = new PdfPCell();
            cellHeaderEmpty.DisableBorderSide(15);
            cellHeaderEmpty.FixedHeight = 50;
            tableHeaderSpacer.AddCell(cellHeaderEmpty);
            doc.Add(tableHeaderSpacer);

            // INFO SECTION
            PdfPTable tableHeaderInfo = new PdfPTable(new float[] { 500f, 300f });

            PdfPCell cellInfoEmpty = new PdfPCell();
            cellInfoEmpty.DisableBorderSide(15);
            tableHeaderInfo.AddCell(cellInfoEmpty);

            PdfPCell cellInfoData = new PdfPCell();
            string datiAmministratore = "Valore netto: " + Calculate(dt);

            string customData = ModelInfo.GetHeaderText();
            if (!string.IsNullOrEmpty(customData))
                datiAmministratore += "\n\n" + customData;

            cellInfoData.Phrase = new Phrase(datiAmministratore, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, 1, new BaseColor(Color.Black)));
            cellInfoData.BorderColor = new BaseColor(255, 255, 255);

            cellInfoData.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            cellInfoData.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cellInfoData.FixedHeight = 50;

            tableHeaderInfo.AddCell(cellInfoData);

            //----------------------------------------------------------------------------------------------------

            // TITLE SECTION
            PdfPTable tableHeaderTitle = new PdfPTable(5);
            PdfPHeaderCell cellHeaderTitle = new PdfPHeaderCell();

            cellHeaderTitle.PaddingLeft = 0;
            cellHeaderTitle.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cellHeaderTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cellHeaderTitle.DisableBorderSide(13);

            cellHeaderTitle.Phrase = new Phrase("MARCA", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, 1, new BaseColor(Color.Black)));
            tableHeaderTitle.AddCell(cellHeaderTitle);
            cellHeaderTitle.Phrase = new Phrase("DESCR.", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, 1, new BaseColor(Color.Black)));
            tableHeaderTitle.AddCell(cellHeaderTitle);

            cellHeaderTitle.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            cellHeaderTitle.PaddingRight = 10;
            cellHeaderTitle.Phrase = new Phrase("QNT.", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, 1, new BaseColor(Color.Black)));
            tableHeaderTitle.AddCell(cellHeaderTitle);
            cellHeaderTitle.PaddingRight = 0;

            cellHeaderTitle.Phrase = new Phrase("Imp. unitario", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, 1, new BaseColor(Color.Black)));
            tableHeaderTitle.AddCell(cellHeaderTitle);
            cellHeaderTitle.Phrase = new Phrase("Imp. tot. netto", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, 1, new BaseColor(Color.Black)));
            tableHeaderTitle.AddCell(cellHeaderTitle);
            cellHeaderTitle.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

            doc.Add(tableHeaderInfo);
            doc.Add(tableHeaderTitle);
        }

        static void MakeContent(Document doc, DataTable dt)
        {
            PdfPTable tableContent = new PdfPTable(5);
            int numRow = 1;
            foreach (DataRow row in dt.Rows)
            {
                PdfPCell cellContent = new PdfPCell();
                cellContent.FixedHeight = 35;
                cellContent.PaddingLeft = 0;
                cellContent.PaddingRight = 0;
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                int q = 1;
                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    if (row.Table.Columns[i].ColumnName == "MARCA"
                        || row.Table.Columns[i].ColumnName == "DESCRIZIONE"
                        || row.Table.Columns[i].ColumnName == "QNT"
                        || row.Table.Columns[i].ColumnName == "PREZZO_NETTO")
                    {
                        string? data = row[i].ToString();
                        if (string.IsNullOrEmpty(data))
                            data = "";

                        else if (row.Table.Columns[i].ColumnName == "QNT")
                        {
                            cellContent.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                            cellContent.PaddingRight = 10;
                            cellContent.BorderColor = new BaseColor(200, 200, 200);
                            //cellContent.EnableBorderSide(1);
                            cellContent.Phrase = new Phrase(data, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, 1, new BaseColor(Color.Black)));
                            tableContent.AddCell(cellContent);
                            q = int.Parse(data);
                        }

                        else if (row.Table.Columns[i].ColumnName == "PREZZO_NETTO")
                        {
                            cellContent.EnableBorderSide(4);
                            cellContent.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                            cellContent.PaddingRight = 0;
                            cellContent.BorderColor = new BaseColor(200, 200, 200);
                            //cellContent.EnableBorderSide(1);
                            cellContent.Phrase = new Phrase(data, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9, 1, new BaseColor(Color.Black)));
                            tableContent.AddCell(cellContent);
                            cellContent.DisableBorderSide(15);

                            // X QNT
                            data = data.Replace("€", "");
                            double fData = double.Parse(data) * q;
                            string sData = fData.ToString("C", CultureInfo.CurrentCulture);

                            cellContent.Phrase = new Phrase(sData, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9, 1, new BaseColor(Color.Black)));
                            cellContent.BorderColor = new BaseColor(200, 200, 200);
                            cellContent.EnableBorderSide(1);
                            tableContent.AddCell(cellContent);
                        }
                        else
                        {
                            cellContent.DisableBorderSide(15);
                            cellContent.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            cellContent.PaddingRight = 0;
                            cellContent.BorderColor = new BaseColor(200, 200, 200);
                            cellContent.EnableBorderSide(1);
                            cellContent.Phrase = new Phrase(data, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, 0, new BaseColor(Color.Black)));
                            tableContent.AddCell(cellContent);
                            if (numRow == 36)
                            {
                                doc.Add(tableContent);

                                MakeFooter(doc);
                                doc.NewPage();
                                MakeHeader(doc, dt);
                                tableContent = new PdfPTable(5);
                                data = row[--i].ToString();
                                cellContent.Phrase = new Phrase(data, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, 0, new BaseColor(Color.Black)));

                                tableContent.AddCell(cellContent);
                                numRow = 0;
                            }

                            numRow++;
                        }
                    }
                }
            }
            doc.Add(tableContent);
        }


        static void MakeSum(Document doc, DataTable dt)
        {
            PdfPTable tableSum = new PdfPTable(5);
            PdfPCell cellNetto = new PdfPCell();
            cellNetto.DisableBorderSide(15);
            PdfPCell cellIvato = new PdfPCell();
            cellIvato.DisableBorderSide(15);

            float netto = 0;
            int q = 1;
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    if (row.Table.Columns[i].ColumnName == "QNT")
                    {
                        string? data = row[i].ToString();
                        if (data != null)
                            q = int.Parse(data);
                    }
                    if (row.Table.Columns[i].ColumnName == "PREZZO_NETTO")
                    {
                        string? data = row[i].ToString();
                        if (!string.IsNullOrEmpty(data) && data.Contains("€"))
                        {
                            data = data.Replace("€", "");
                            netto += float.Parse(data) * q;

                            cellNetto.PaddingLeft = 0;
                            cellNetto.PaddingRight = 0;
                            cellNetto.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                            cellNetto.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                            cellNetto.EnableBorderSide(1);

                            string sData = netto.ToString("C", CultureInfo.CurrentCulture);

                            cellNetto.Phrase = new Phrase(sData, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9, 1, new BaseColor(Color.Black)));

                        }
                    }
                }
            }
            PdfPCell emptyCell = new PdfPCell();
            emptyCell.DisableBorderSide(15);
            emptyCell.EnableBorderSide(1);
            tableSum.AddCell(emptyCell);
            tableSum.AddCell(emptyCell);
            tableSum.AddCell(emptyCell);
            tableSum.AddCell(emptyCell);

            tableSum.AddCell(cellNetto);

            doc.Add(tableSum);
        }


        static void MakeFooter(Document doc)
        {
            PdfPTable tableFooter = new PdfPTable(1);

            PdfPCell emptyCell = new PdfPCell();
            emptyCell.DisableBorderSide(15);
            emptyCell.EnableBorderSide(1);
            tableFooter.AddCell(emptyCell);

            doc.Add(tableFooter);
        }

        static string Calculate(DataTable dt)
        {
            string sData = "";
            float netto = 0;
            int q = 1;
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    if (row.Table.Columns[i].ColumnName == "QNT")
                    {
                        string? data = row[i].ToString();
                        if (data != null)
                            q = int.Parse(data);
                    }
                    if (row.Table.Columns[i].ColumnName == "PREZZO_NETTO")
                    {
                        string? data = row[i].ToString();
                        if (!string.IsNullOrEmpty(data) && data.Contains("€"))
                        {
                            data = data.Replace("€", "");
                            netto += float.Parse(data) * q;

                            sData = netto.ToString("C", CultureInfo.CurrentCulture);
                        }
                    }
                }
            }
            return sData;
        }


        //------------------------------------------------
        static void MakeHeader_old(Document doc, DataTable dt)
        {
            // LOGO SECTION
            iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(Properties.Resources.CapelliAndManieBW, System.Drawing.Imaging.ImageFormat.Png);
            pic.ScaleToFit(300f, 100f);
            pic.SetAbsolutePosition(58, 720);
            doc.Add(pic);
            //----------------------------------------------------------------------------------------------------

            // SPACER
            PdfPTable tableHeaderSpacer = new PdfPTable(1);
            PdfPCell cellHeaderEmpty = new PdfPCell();
            cellHeaderEmpty.DisableBorderSide(15);
            cellHeaderEmpty.FixedHeight = 50;
            tableHeaderSpacer.AddCell(cellHeaderEmpty);
            doc.Add(tableHeaderSpacer);

            // INFO SECTION
            PdfPTable tableHeaderInfo = new PdfPTable(new float[] { 500f, 300f });

            PdfPCell cellInfoEmpty = new PdfPCell();
            cellInfoEmpty.DisableBorderSide(15);
            tableHeaderInfo.AddCell(cellInfoEmpty);

            PdfPCell cellInfoData = new PdfPCell();
            string datiAmministratore = "Valore netto: " + Calculate(dt);

            string customData = ModelInfo.GetHeaderText();
            if (!string.IsNullOrEmpty(customData))
                datiAmministratore += "\n\n" + customData;

            cellInfoData.Phrase = new Phrase(datiAmministratore, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, 1, new BaseColor(Color.Black)));
            cellInfoData.BorderColor = new BaseColor(255, 255, 255);

            cellInfoData.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            cellInfoData.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cellInfoData.FixedHeight = 50;

            tableHeaderInfo.AddCell(cellInfoData);

            //----------------------------------------------------------------------------------------------------

            // TITLE SECTION
            PdfPTable tableHeaderTitle = new PdfPTable(6);
            PdfPHeaderCell cellHeaderTitle = new PdfPHeaderCell();

            cellHeaderTitle.PaddingLeft = 0;
            cellHeaderTitle.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cellHeaderTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cellHeaderTitle.DisableBorderSide(13);

            cellHeaderTitle.Phrase = new Phrase("MARCA", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, 1, new BaseColor(Color.Black)));
            tableHeaderTitle.AddCell(cellHeaderTitle);
            cellHeaderTitle.Phrase = new Phrase("DESCR.", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, 1, new BaseColor(Color.Black)));
            tableHeaderTitle.AddCell(cellHeaderTitle);

            cellHeaderTitle.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            cellHeaderTitle.PaddingRight = 10;
            cellHeaderTitle.Phrase = new Phrase("QNT.", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, 1, new BaseColor(Color.Black)));
            tableHeaderTitle.AddCell(cellHeaderTitle);
            cellHeaderTitle.PaddingRight = 0;

            cellHeaderTitle.Phrase = new Phrase("Imp. unitario", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, 1, new BaseColor(Color.Black)));
            tableHeaderTitle.AddCell(cellHeaderTitle);
            cellHeaderTitle.Phrase = new Phrase("Imp. tot. netto", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, 1, new BaseColor(Color.Black)));
            tableHeaderTitle.AddCell(cellHeaderTitle);
            cellHeaderTitle.Phrase = new Phrase("Imp. tot. ivato", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, 1, new BaseColor(Color.Black)));
            tableHeaderTitle.AddCell(cellHeaderTitle);
            cellHeaderTitle.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

            doc.Add(tableHeaderInfo);
            doc.Add(tableHeaderTitle);
        }
        static void MakeContent_old(Document doc, DataTable dt)
        {
            PdfPTable tableContent = new PdfPTable(6);
            int numRow = 1;
            foreach (DataRow row in dt.Rows)
            {
                PdfPCell cellContent = new PdfPCell();
                cellContent.FixedHeight = 35;
                cellContent.PaddingLeft = 0;
                cellContent.PaddingRight = 0;
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

                int q = 1;
                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    if (row.Table.Columns[i].ColumnName == "MARCA"
                        || row.Table.Columns[i].ColumnName == "DESCRIZIONE"
                        || row.Table.Columns[i].ColumnName == "QNT"
                        || row.Table.Columns[i].ColumnName == "PREZZO_NETTO"
                        || row.Table.Columns[i].ColumnName == "PREZZO_IVATO")
                    {
                        string? data = row[i].ToString();
                        if (string.IsNullOrEmpty(data))
                            data = "";

                        else if (row.Table.Columns[i].ColumnName == "QNT")
                        {
                            cellContent.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                            cellContent.PaddingRight = 10;
                            cellContent.BorderColor = new BaseColor(200, 200, 200);
                            //cellContent.EnableBorderSide(1);
                            cellContent.Phrase = new Phrase(data, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, 1, new BaseColor(Color.Black)));
                            tableContent.AddCell(cellContent);
                            q = int.Parse(data);
                        }

                        else if (row.Table.Columns[i].ColumnName == "PREZZO_NETTO")
                        {
                            cellContent.EnableBorderSide(4);
                            cellContent.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                            cellContent.PaddingRight = 0;
                            cellContent.BorderColor = new BaseColor(200, 200, 200);
                            //cellContent.EnableBorderSide(1);
                            cellContent.Phrase = new Phrase(data, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9, 1, new BaseColor(Color.Black)));
                            tableContent.AddCell(cellContent);
                            cellContent.DisableBorderSide(15);

                            // X QNT
                            data = data.Replace("€", "");
                            double fData = double.Parse(data) * q;
                            string sData = fData.ToString("C", CultureInfo.CurrentCulture);

                            cellContent.Phrase = new Phrase(sData, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9, 1, new BaseColor(Color.Black)));
                            cellContent.BorderColor = new BaseColor(200, 200, 200);
                            cellContent.EnableBorderSide(1);
                            tableContent.AddCell(cellContent);
                        }
                        else if (row.Table.Columns[i].ColumnName == "PREZZO_IVATO")
                        {
                            cellContent.DisableBorderSide(15);
                            cellContent.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                            cellContent.PaddingRight = 0;
                            cellContent.BorderColor = new BaseColor(210, 210, 210);
                            cellContent.EnableBorderSide(1);

                            data = data.Replace("€", "");
                            double fData = double.Parse(data) * q;
                            string sData = fData.ToString("C", CultureInfo.CurrentCulture);

                            cellContent.Phrase = new Phrase(sData, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9, 1, new BaseColor(Color.Black)));
                            tableContent.AddCell(cellContent);
                        }
                        else
                        {
                            cellContent.DisableBorderSide(15);
                            cellContent.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                            cellContent.PaddingRight = 0;
                            cellContent.BorderColor = new BaseColor(200, 200, 200);
                            cellContent.EnableBorderSide(1);
                            cellContent.Phrase = new Phrase(data, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, 0, new BaseColor(Color.Black)));
                            tableContent.AddCell(cellContent);
                            if (numRow == 36)
                            {
                                doc.Add(tableContent);

                                MakeFooter(doc);
                                doc.NewPage();
                                MakeHeader(doc, dt);
                                tableContent = new PdfPTable(6);
                                data = row[--i].ToString();
                                cellContent.Phrase = new Phrase(data, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, 0, new BaseColor(Color.Black)));

                                tableContent.AddCell(cellContent);
                                numRow = 0;
                            }

                            numRow++;
                        }
                    }
                }
            }
            doc.Add(tableContent);
        }
        static void MakeSum_old(Document doc, DataTable dt)
        {
            PdfPTable tableSum = new PdfPTable(6);
            PdfPCell cellNetto = new PdfPCell();
            cellNetto.DisableBorderSide(15);
            PdfPCell cellIvato = new PdfPCell();
            cellIvato.DisableBorderSide(15);

            float netto = 0;
            float ivato = 0;
            int q = 1;
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    if (row.Table.Columns[i].ColumnName == "QNT")
                    {
                        string? data = row[i].ToString();
                        if (data != null)
                            q = int.Parse(data);
                    }
                    if (row.Table.Columns[i].ColumnName == "PREZZO_NETTO")
                    {
                        string? data = row[i].ToString();
                        if (!string.IsNullOrEmpty(data) && data.Contains("€"))
                        {
                            data = data.Replace("€", "");
                            netto += float.Parse(data) * q;

                            cellNetto.PaddingLeft = 0;
                            cellNetto.PaddingRight = 0;
                            cellNetto.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                            cellNetto.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                            cellNetto.EnableBorderSide(1);

                            string sData = netto.ToString("C", CultureInfo.CurrentCulture);

                            cellNetto.Phrase = new Phrase(sData, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9, 1, new BaseColor(Color.Black)));

                        }
                    }

                    if (row.Table.Columns[i].ColumnName == "PREZZO_IVATO")
                    {
                        string? data = row[i].ToString();
                        if (!string.IsNullOrEmpty(data) && data.Contains("€"))
                        {
                            data = data.Replace("€", "");
                            ivato += float.Parse(data) * q;

                            cellIvato.PaddingLeft = 0;
                            cellIvato.PaddingRight = 0;
                            cellIvato.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                            cellIvato.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                            cellIvato.EnableBorderSide(1);

                            string sData = ivato.ToString("C", CultureInfo.CurrentCulture);

                            cellIvato.Phrase = new Phrase(sData, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 9, 1, new BaseColor(Color.Black)));

                        }
                    }
                }
            }
            PdfPCell emptyCell = new PdfPCell();
            emptyCell.DisableBorderSide(15);
            emptyCell.EnableBorderSide(1);
            tableSum.AddCell(emptyCell);
            tableSum.AddCell(emptyCell);
            tableSum.AddCell(emptyCell);
            tableSum.AddCell(emptyCell);

            tableSum.AddCell(cellNetto);
            tableSum.AddCell(cellIvato);

            doc.Add(tableSum);
        }


    }
}
