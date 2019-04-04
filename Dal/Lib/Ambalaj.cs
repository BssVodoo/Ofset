using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace NZF_DAL
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;

    public class Ambalaj : DataAccesBase
    {

        string m_SQL;
        int m_ConCount;
		int m_ID; 


        public String AResim;
        public String AAciklama;
        public String ABaslik;
		    


        public int ID
        {
            get { return m_ID; }
        }

        public Ambalaj ()
        {
        }
        public Ambalaj (int pID)
        {
            m_SQL = "Select * from Ambalaj where ID=" + pID;
            initialize();
        }

        public Ambalaj(string pFIELD_NAME, string pVALUE)
        {
            m_SQL = "Select * from Ambalaj where " + pFIELD_NAME + "='" + pVALUE + "'";
            initialize();
        }
 

        public bool initialize()
        {
            DataTable DT = ReturnDataTable(m_SQL);
            try
            {
                m_ConCount = DT.Rows.Count;
                if (DT.Rows.Count == 0)
                {
                    m_ID = 0;
                    return true;
                }
                m_ID = Convert.ToInt32( DT.Rows[0]["ID"]);
                AResim = Convert.ToString(DT.Rows[0]["AResim"]);
                AAciklama = Convert.ToString(DT.Rows[0]["AAciklama"]);
                ABaslik = Convert.ToString(DT.Rows[0]["ABaslik"]);

                DT.Dispose();
            }
            catch (Exception ex)
            {
            }
            return true;
        }

       public void Kaydet()
        {
            if (Kontrol())
            {
                switch (m_ID)
                {
                    case 0:
                        KaydetInsert();
                        break;
                    default:
                        KaydetUpdate();
                        break;
                }
            }
        }


        public bool Kontrol()
        {
            return true;
        }

		
		
		
		private int KaydetInsert()
        {
            string SQL = null;

			SQL="Insert Into Ambalaj (AResim, AAciklama, ABaslik) values (";
            SQL += "'" + AResim + "',";
            SQL += "'" + AAciklama + "',";
            SQL += "'" + ABaslik + "'  ";
            SQL += ") SELECT @@IDENTITY AS ID ";   

            DataSet DS = new DataSet();
            try
            {
                this.FillDataSet(DS, SQL);
                if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                {
                    m_ID = int.Parse(DS.Tables[0].Rows[0]["ID"].ToString());

                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message + " Hatasql:" + SQL);
            }
            finally
            {
                DS.Dispose();
            }
            return 0;
        }
		
		
		
		
		
		
         private int KaydetUpdate()
        {
            string SQL = null;

            SQL = "UPDATE Ambalaj SET ";
            SQL += "AResim='" + AResim + "',";
            SQL += "AAciklama='" + AAciklama + "',";
            SQL += "ABaslik='" + ABaslik + "'  ";
            SQL += " WHERE ID=" + m_ID;

            try
            {
                this.ExecuteSQL(SQL);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message + " Hatasql:" + SQL);
            }
            return 0;
        }
	
	
	
	
	
	
       public object Delete()
        {
            m_SQL = "Delete from Ambalaj where ID=" + m_ID;
            this.ExecuteSQL(m_SQL);
            return true;
        }

 
	}
}	

