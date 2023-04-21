using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System.Data;
using System.Data.SqlClient;
using System;


namespace DotNet_Autocad
{
    public class DBLoadUtil
    {
        //method to load all lines object into database
        public string LoadLines()
        {
            string result = "";
            SqlConnection conn = DBUtil.GetConnection();
            try
            {
                //get all the document and Editor object
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Editor ed = doc.Editor;

                //Do the transaction now
                using (Transaction trans = doc.TransactionManager.StartTransaction())
                {
                    //Need to filter to make sure we only get line objects
                    TypedValue[] tv = new TypedValue[1];
                    tv.SetValue(new TypedValue((int)DxfCode.Start, "LINE"), 0);
                    SelectionFilter filter = new SelectionFilter(tv);

                    PromptSelectionResult ssPrompt = ed.SelectAll(filter);
                    //Check if there is object selected
                    if (ssPrompt.Status == PromptStatus.OK)
                    {
                        double startPtX = 0.0, startPtY = 0.0, endPtX = 0.0, endPtY = 0.0;
                        string layer = "", ltype = "", color = "";
                        double len = 0.0;
                        Line line = new Line();
                        SelectionSet ss = ssPrompt.Value;

                        //write sql query by using insert statement
                        string sql = @"INSERT INTO DBO.LINES (StartPtX, StartPtY, EndPtX, EndPtY, Layer, Color, Linetype, Length, Created)
                                    VALUES(@StartPtX, @StartPtY, @EndPtX, @EndPtY, @Layer, @Color, @Linetype, @Length, @Created)";
                        conn.Open();

                        //Loop through the selection set and insert into database one line object at a time 
                        foreach (SelectedObject sObj in ss)
                        {
                            line = trans.GetObject(sObj.ObjectId, OpenMode.ForRead) as Line;
                            startPtX = line.StartPoint.X;
                            startPtY = line.StartPoint.Y;
                            endPtX = line.EndPoint.X;
                            endPtY = line.EndPoint.Y;
                            layer = line.Layer;
                            ltype = line.Linetype;
                            color = line.Linetype;
                            len = line.Length;

                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@StartPtX", startPtX);
                            cmd.Parameters.AddWithValue("@StartPtY", startPtY);
                            cmd.Parameters.AddWithValue("@EndPtX", endPtX);
                            cmd.Parameters.AddWithValue("@EndPtY", endPtY);
                            cmd.Parameters.AddWithValue("@Layer", layer);
                            cmd.Parameters.AddWithValue("@Color", color);
                            cmd.Parameters.AddWithValue("@Linetype", ltype);
                            cmd.Parameters.AddWithValue("@Length", len);
                            cmd.Parameters.AddWithValue("@Created", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }

                    }
                    else
                    {
                        ed.WriteMessage("No object selected.");
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }



        //method to load all mtexts object into database
        public string LoadMTexts()
        {
            string result = "";
            SqlConnection conn = DBUtil.GetConnection();
            try
            {
                //get all the document and Editor object
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Editor ed = doc.Editor;

                //Do the transaction now
                using (Transaction trans = doc.TransactionManager.StartTransaction())
                {
                    //Need to filter to make sure we only get line objects
                    TypedValue[] tv = new TypedValue[1];
                    tv.SetValue(new TypedValue((int)DxfCode.Start, "MTEXT"), 0);
                    SelectionFilter filter = new SelectionFilter(tv);

                    PromptSelectionResult ssPrompt = ed.SelectAll(filter);
                    //Check if there is object selected
                    if (ssPrompt.Status == PromptStatus.OK)
                    {
                        double insPtX = 0.0, insPtY = 0.0;
                        string layer = "", textstyle = "", color = "";
                        double height = 0.0, width = 0.0;
                        string tx = "";
                        int attachment;

                        MText mtx = new MText();
                        SelectionSet ss = ssPrompt.Value;

                        //write sql query by using insert statement
                        string sql = @"INSERT INTO DBO.Mtexts (insPtX, insPtY, Layer, Color, TextStyle, Height, Width, Text, Attachment,Created)
                                    VALUES(@InsPtX, @InsPtY, @Layer, @Color, @Textstyle, @Height, @Width, @Text , @Attachment, @Created)";
                        conn.Open();

                        //Loop through the selection set and insert into database one line object at a time 
                        foreach (SelectedObject sObj in ss)
                        {
                            mtx = trans.GetObject(sObj.ObjectId, OpenMode.ForRead) as MText;
                            insPtX = mtx.Location.X;
                            insPtY = mtx.Location.Y;
                            layer = mtx.Layer;
                            color = mtx.Color.ToString();
                            textstyle = mtx.TextStyleName;
                            color = mtx.Linetype;
                            height = mtx.TextHeight;
                            width = mtx.Width;
                            attachment = Convert.ToInt32(mtx.Attachment);


                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@InsPtX", insPtX);
                            cmd.Parameters.AddWithValue("@InsPtY", insPtY);
                            cmd.Parameters.AddWithValue("@Layer", layer);
                            cmd.Parameters.AddWithValue("@Color", color);
                            cmd.Parameters.AddWithValue("@TextStyle", textstyle);
                            cmd.Parameters.AddWithValue("@Height", height);
                            cmd.Parameters.AddWithValue("@Text", tx);
                            cmd.Parameters.AddWithValue("@Width", width);
                            cmd.Parameters.AddWithValue("@Attachment", attachment);
                            cmd.Parameters.AddWithValue("@Created", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }

                    }
                    else
                    {
                        ed.WriteMessage("No object selected.");
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }



        //method to load all the polylines object into database
        public string LoadPolylines()
        {
            string result = "";
            SqlConnection conn = DBUtil.GetConnection();
            try
            {
                //get all the document and Editor object
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Editor ed = doc.Editor;

                //Do the transaction now
                using (Transaction trans = doc.TransactionManager.StartTransaction())
                {
                    //Need to filter to make sure we only get line objects
                    TypedValue[] tv = new TypedValue[1];
                    tv.SetValue(new TypedValue((int)DxfCode.Start, "LWPOLYLINE"), 0);
                    SelectionFilter filter = new SelectionFilter(tv);

                    PromptSelectionResult ssPrompt = ed.SelectAll(filter);
                    //Check if there is object selected
                    if (ssPrompt.Status == PromptStatus.OK)
                    {
                        string layer = "", ltype = "";
                        string coords = "";
                        double len = 0.0;
                        bool isClosed = false;
                        Polyline pline = new Polyline();
                        SelectionSet ss = ssPrompt.Value;

                        //write sql query by using insert statement
                        string sql = @"INSERT INTO DBO.PLINES (Layer, Linetype, Length, Coordinates, IsClosed, Created)
                                    VALUES( @Layer, @Linetype, @Length, @Coordinates, @IsClosed, @Created)";
                        conn.Open();

                        //Loop through the selection set and insert into database one line object at a time 
                        foreach (SelectedObject sObj in ss)
                        {
                            pline = trans.GetObject(sObj.ObjectId, OpenMode.ForRead) as Polyline;

                            layer = pline.Layer;
                            ltype = pline.Linetype;
                            len = pline.Length;
                            isClosed = pline.Closed;
                            coords = CommonUtil.GetPolylineCoordinates(pline);


                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@Layer", layer);
                            cmd.Parameters.AddWithValue("@Linetype", ltype);
                            cmd.Parameters.AddWithValue("@Length", len);
                            cmd.Parameters.AddWithValue("@Coordinates", coords);
                            cmd.Parameters.AddWithValue("@IsClosed", isClosed);
                            cmd.Parameters.AddWithValue("@Created", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }

                    }
                    else
                    {
                        ed.WriteMessage("No object selected.");
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }




        //method to load all blocks with no attributes object into database
        public string LoadBlocksNoAttribute()
        {
            string result = "";
            SqlConnection conn = DBUtil.GetConnection();
            try
            {
                //get all the document and Editor object
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Editor ed = doc.Editor;

                //Do the transaction now
                using (Transaction trans = doc.TransactionManager.StartTransaction())
                {
                    //Need to filter to make sure we only get line objects
                    TypedValue[] tv = new TypedValue[1];
                    tv.SetValue(new TypedValue((int)DxfCode.Start, "INSERT"), 0);
                    SelectionFilter filter = new SelectionFilter(tv);

                    PromptSelectionResult ssPrompt = ed.SelectAll(filter);
                    //Check if there is object selected
                    if (ssPrompt.Status == PromptStatus.OK)
                    {
                        double insPtX = 0.0, insPtY = 0.0;
                        string blkname = "";
                        string layer = "", ltype = "", color = "";
                        double rotation = 0.0;
                        string insPt = "";
                        BlockReference blk;
                        SelectionSet ss = ssPrompt.Value;

                        //write sql query by using insert statement
                        string sql = @"INSERT INTO DBO.BlocksNoAttribute (insertionPt, BlockName, Layer, Rotation, Created)
                                    VALUES(@InsertionPt, @BlockName, @Layer, @Rotation, @Created)";
                        conn.Open();

                        //Loop through the selection set and insert into database one line object at a time 
                        foreach (SelectedObject sObj in ss)
                        {
                            blk = trans.GetObject(sObj.ObjectId, OpenMode.ForRead) as BlockReference;
                            if (blk.AttributeCollection.Count == 0 & !blk.Name.Contains("*"))
                            {
                                insPtX = blk.Position.X;
                                insPtY = blk.Position.Y;
                                insPt = insPtX.ToString() + "," + insPtY.ToString();
                                blkname = blk.Name;
                                layer = blk.Layer;
                                rotation = blk.Rotation;

                                SqlCommand cmd = new SqlCommand(sql, conn);
                                cmd.Parameters.AddWithValue("@insertionPt", insPt);
                                cmd.Parameters.AddWithValue("@BlockName", blkname);
                                cmd.Parameters.AddWithValue("@Layer", layer);
                                cmd.Parameters.AddWithValue("@Rotation", rotation);
                                cmd.Parameters.AddWithValue("@Created", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                        }

                    }
                    else
                    {
                        ed.WriteMessage("No object selected.");
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }



        //method to load all blocks with attributes object into database
        public string LoadBlocksWithAttribute()
        {
            string result = "";
            SqlConnection conn = DBUtil.GetConnection();
            try
            {
                //get all the document and Editor object
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Editor ed = doc.Editor;

                //Do the transaction now
                using (Transaction trans = doc.TransactionManager.StartTransaction())
                {
                    //Need to filter to make sure we only get line objects
                    TypedValue[] tv = new TypedValue[1];
                    tv.SetValue(new TypedValue((int)DxfCode.Start, "INSERT"), 0);
                    SelectionFilter filter = new SelectionFilter(tv);

                    PromptSelectionResult ssPrompt = ed.SelectAll(filter);
                    //Check if there is object selected
                    if (ssPrompt.Status == PromptStatus.OK)
                    {
                        double insPtX = 0.0, insPtY = 0.0;
                        string blkname = "";
                        string layer = "", ltype = "", color = "";
                        double rotation = 0.0;
                        string insPt = "";
                        string attributes = "";
                        BlockReference blk;
                        SelectionSet ss = ssPrompt.Value;

                        //write sql query by using insert statement
                        string sql = @"INSERT INTO DBO.BlocksNoAttribute (insertionPt, BlockName, Layer, Attributes, Rotation, Created)
                                    VALUES(@InsertionPt, @BlockName, @Layer, @Attributes, @Rotation, @Created)";
                        conn.Open();

                        //Loop through the selection set and insert into database one line object at a time 
                        foreach (SelectedObject sObj in ss)
                        {
                            blk = trans.GetObject(sObj.ObjectId, OpenMode.ForRead) as BlockReference;
                            if (blk.AttributeCollection.Count > 0 & !blk.Name.Contains("*"))
                            {
                                insPtX = blk.Position.X;
                                insPtY = blk.Position.Y;
                                insPt = insPtX.ToString() + "," + insPtY.ToString();
                                blkname = blk.Name;
                                layer = blk.Layer;
                                rotation = blk.Rotation;

                                //loop through attributes
                                foreach(ObjectId attRefId in blk.AttributeCollection)
                                {
                                    DBObject obj = trans.GetObject(attRefId, OpenMode.ForRead);
                                    AttributeReference attRef = obj as AttributeReference;
                                    if(attRef != null)
                                    {
                                        attributes += attRef.Tag + "=" + attRef.TextString + ",";
                                    }
                                }
                                attributes = attributes.Substring(0, attributes.Length - 1);

                                SqlCommand cmd = new SqlCommand(sql, conn);
                                cmd.Parameters.AddWithValue("@insertionPt", insPt);
                                cmd.Parameters.AddWithValue("@BlockName", blkname);
                                cmd.Parameters.AddWithValue("@Layer", layer);
                                cmd.Parameters.AddWithValue("@Rotation", rotation);
                                cmd.Parameters.AddWithValue("@Attributes", attributes);
                                cmd.Parameters.AddWithValue("@Created", DateTime.Now);
                                cmd.ExecuteNonQuery();

                                attributes = "";
                            }
                        }

                    }
                    else
                    {
                        ed.WriteMessage("No object selected.");
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }
    }
}
