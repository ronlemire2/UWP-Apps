using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SfDataGridDemo.ViewModels;
using System.Collections.ObjectModel;

namespace SfDataGridDemo.Services {
    public class ProductRepository : IProductRepository {
        static Random r = new Random();

        #region Constructors

        public List<ProductViewModel> GetProductVMs(int count) {
            SetProduct();
            SetProductPrice();
            ProductVMs = new List<ProductViewModel>();
            PopulateProductVMs(count);
            return ProductVMs;
        }

        #endregion

        #region Properties

        private List<ProductViewModel> productVMs;
        public List<ProductViewModel> ProductVMs {
            get { return productVMs; }
            set { productVMs = value; }
        }

        #endregion

        #region Helpers

        Dictionary<string, string[]> ProductDict = new Dictionary<string, string[]>();
        Dictionary<string, string[]> ProductModelDict = new Dictionary<string, string[]>();
        Dictionary<string, int> ProductPriceDict = new Dictionary<string, int>();

        string[] ProductNames = new string[]
        {
            "Laptop",
            "Mobile",
            "Watch",
            "Footware"
        };

        private void SetProduct() {
            string[] laptop = new string[] { "Dell", "HP", "Asus", "Sony", "Apple", "Lenovo" };
            string[] mobile = new string[] { "Nokia", "Samsung", "SonyMobile", "HTC", "IPhone" };
            string[] watch = new string[] { "FastTrack", "ROLEX", "Casio", "Geneva", "Seiko" };
            string[] footware = new string[] { "Reebok", "Puma" };

            ProductDict.Add("Laptop", laptop);
            ProductDict.Add("Mobile", mobile);
            ProductDict.Add("Watch", watch);
            ProductDict.Add("Footware", footware);

            ProductModelDict.Add("Dell", new string[] { "XPS15", "XPS12" });
            ProductModelDict.Add("HP", new string[] { "Pavilion_G6", "Envy_X2" });
            ProductModelDict.Add("Asus", new string[] { "Transformer" });
            ProductModelDict.Add("Sony", new string[] { "Vaio" });
            ProductModelDict.Add("Apple", new string[] { "Macbook_Air", "Macbook_Pro2" });
            ProductModelDict.Add("Lenovo", new string[] { "Yoga" });

            ProductModelDict.Add("Nokia", new string[] { "Lumia_920", "Lumia_800" });
            ProductModelDict.Add("Samsung", new string[] { "S3" });
            ProductModelDict.Add("SonyMobile", new string[] { "Xperia_Tipo", "Xperia_Z" });
            ProductModelDict.Add("IPhone", new string[] { "Iphone5" });
            ProductModelDict.Add("HTC", new string[] { "8x", "One_X" });

            ProductModelDict.Add("FastTrack", new string[] { "Fastrack", "Men_Black" });
            ProductModelDict.Add("Casio", new string[] { "G-Shock" });
            ProductModelDict.Add("Geneva", new string[] { "Carrera", "Monaco" });
            ProductModelDict.Add("Seiko", new string[] { "Aquaracer" });
            ProductModelDict.Add("ROLEX", new string[] { "Sea_Dweller Deepsea", "Submariner" });

            ProductModelDict.Add("Puma", new string[] { "Aquil", "Axis_XT" });
            ProductModelDict.Add("Reebok", new string[] { "Advantage_Runner", "FieldEffect", "RunCruise" });
        }

        private void SetProductPrice() {
            ProductPriceDict.Add("Laptop", r.Next(1200, 1500));
            ProductPriceDict.Add("Mobile", r.Next(250, 350));
            ProductPriceDict.Add("Watch", r.Next(120, 150));
            ProductPriceDict.Add("Footware", r.Next(35, 45));
        }

        string[] CustomerId = new string[]
        {
            "ALFKI",
            "FRANS",
            "MEREP",
            "FOLKO",
            "SIMOB",
            "WARTH",
            "VAFFE",
            "FURIB",
            "SEVES",
            "LINOD",
            "RISCU",
            "PICCO",
            "BLONP",
            "WELLI",
            "FOLIG"
        };


        string[] ProductNames2 = new string[]
        {
            "Alice Mutton",
            "NuNuCa Nuß-Nougat-Creme",
            "Boston Crab Meat",
            "Raclette Courdavault",
            "Wimmers gute Semmelknödel",
            "Gorgonzola Telino",
            "Chartreuse verte",
            "Fløtemysost",
            "Carnarvon Tigers",
            "Thüringer Rostbratwurst",
            "Vegie-spread",
            "Tarte au sucre",
            "Konbu",
            "Valkoinen suklaa",
            "Queso Manchego La Pastora",
            "Perth Pasties",
            "Vegie-spread",
            "Tofu",
            "Sir Rodney's Scone 7",
            "Manjimup Dried Apples"
        };

        private void PopulateProductVMs(int count) {
            for (int i = 0; i < count; i++) {
                ProductViewModel productVM = new ProductViewModel();

                var productName = ProductNames[r.Next(ProductNames.Count() - 1)];
                var productCollection = ProductDict[productName];
                productVM.ProductId = 10000 + i;
                productVM.UserRating = r.Next(3, 5);
                productVM.ShippingDays = r.Next(1, 5);
                productVM.ProductType = productName;
                productVM.ProductName = productCollection[r.Next(productCollection.Length - 1)];
                var productModel = ProductModelDict[productVM.ProductName];
                productVM.ProductBrand = productVM.ProductName;
                productVM.Availability = r.Next(0, 20) % 5 == 0 ? false : true;
                productVM.Price = ProductPriceDict[productName];
                productVM.ProductModel = productModel[r.Next(productModel.Count())];

                //productVM.ProductName = ProductNames2[r.Next(20)];
                productVM.Year2008 = Convert.ToDecimal(Math.Round(r.Next(2000) + r.NextDouble(), 2));
                productVM.Year2009 = Convert.ToDecimal(Math.Round(r.Next(250) + r.NextDouble(), 2));
                productVM.Year2010 = Convert.ToDecimal(Math.Round(r.Next(300) + r.NextDouble(), 2));
                productVM.Year2011 = Convert.ToDecimal(Math.Round(r.Next(550) + r.NextDouble(), 2));
                productVM.Year2012 = Convert.ToDecimal(Math.Round(r.Next(700) + r.NextDouble(), 2));
                productVM.Year2013 = Convert.ToDecimal(Math.Round(r.Next(1000) + r.NextDouble(), 2));
                productVM.TotalSales = productVM.Year2008 + 
                productVM.Year2009 + productVM.Year2010 + productVM.Year2011 + 
                productVM.Year2012 + productVM.Year2013;

                this.ProductVMs.Add(productVM);
            }
        }
        #endregion


    }
}
