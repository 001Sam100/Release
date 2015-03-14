using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

public partial class serialization_deserialization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Serialization();
    }
    protected void deserial_Click(object sender, EventArgs e)
    {
        
    }

    public class Category
    {
        private int _CatID;
        private string _CatName;
        private Item[] _Item;

        public int CategoryID
        {
            get
            {
                return _CatID;
            }
            set
            {
                _CatID = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return _CatName;
            }
            set
            {
                _CatName = value;
            }
        }


        public Item[] Item
        {
            get
            {
                return _Item;
            }
            set
            {
                _Item = value;
            }
        }
    }

    public class Item
    {
        private int _ItemID;
        private string _ItemName;
        private int _ItemPrice;
        private int _ItemQtyInStock;

        public int ItemID
        {
            get
            {
                return _ItemID;
            }
            set
            {
                _ItemID = value;
            }
        }

        public string ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                _ItemName = value;
            }
        }

        public int ItemPrice
        {
            get
            {
                return _ItemPrice;
            }
            set
            {
                _ItemPrice = value;
            }
        }

        public int ItemQtyInStock
        {
            get
            {
                return _ItemQtyInStock;
            }
            set
            {
                _ItemQtyInStock = value;
            }
        }
    }

    private void Serialization()
    {
        Category Cat = new Category();
        Cat.CategoryID = 1;
        Cat.CategoryName = "Phone";
        Item[] Itm = new Item[5];
        for (int i = 0; i < 5; i++)
        {
            Itm[i] = new Item();
            Itm[i].ItemID = i;
            Itm[i].ItemPrice = i * 10;
            Itm[i].ItemQtyInStock = i + 10;
            Itm[i].ItemName = " Item Name : " + i.ToString();

        }
        Cat.Item = Itm;
        XmlSerializer ser = new XmlSerializer(Cat.GetType());
        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //System.IO.StringWriter writer = new System.IO.StringWriter(sb);
        //ser.Serialize(writer, Cat); 	// Here Classes are converted to XML String. 
        //// This can be viewed in SB or writer.
        //// Above XML in SB can be loaded in XmlDocument object
        //XmlDocument doc = new XmlDocument();
        //doc.LoadXml(sb.ToString());
        TextWriter tw = new StreamWriter(@"C:\\Users\\Sam\\Documents\\Visual Studio 2010\\WebSites\\Login\\App_Data\\Ads.xml");
        ser.Serialize(tw, Cat);
        tw.Close();
    }

    protected void DeSerialize(string XmlString)
    {
        Category Cat = new Category();
        XmlDocument doc = new XmlDocument();
        doc.LoadXml (XmlString);
        XmlNodeReader reader = new XmlNodeReader(doc.DocumentElement);
        XmlSerializer ser = new XmlSerializer(Cat.GetType());
        object obj = ser.Deserialize(reader);
        // Then you just need to cast obj into whatever type it is, e.g.:
        Category myObj = (Category)obj;
    }
   
}