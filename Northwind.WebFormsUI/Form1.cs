using Northwind.Bussiunes.Abstract;
using Northwind.Bussiunes.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Concrete.NhHibernate;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
        }

        private IProductService _productService;
        private ICategoryService _categoryService;

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        // Category deki Tüm ürünleri Combobox a yükler.
        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            cbxCategoryId.DataSource = _categoryService.GetAll();
            cbxCategoryId.DisplayMember = "CategoryName";
            cbxCategoryId.ValueMember = "CategoryId";

            cbxCategoryUpdate.DataSource = _categoryService.GetAll();
            cbxCategoryUpdate.DisplayMember = "CategoryName";
            cbxCategoryUpdate.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        // ComboBox ta seçilen kategoriye göre ürünleri DataGridView e yükler.
        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // _productService de CategoryId Kullanarak ürünleri filtreleyip onları DataGridView e yükler.
                dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }

            catch
            {

            }
        }

        private void tbxProduct_TextChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(tbxProduct.Text))
            {
                dgwProduct.DataSource = _productService.GetProductByPropductName(tbxProduct.Text);
            }

            else
            {
                LoadProducts();
            }
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            _productService.AddProducts(new Product
            {
               CategoryId = Convert.ToInt32(cbxCategoryId.SelectedValue),
               ProductName = tbxProductName.Text,
               UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
               QuantityPerUnit = tbxQuantityPerUnit.Text,
               UnitsInStock = Convert.ToInt16(tbxUnitInStock.Text)
            });
            MessageBox.Show("Ürün Eklendi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.ProductUpdate(new Product
            {
                ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                ProductName = tbxProductNameUpdate.Text,
                CategoryId = Convert.ToInt32(cbxCategoryUpdate.SelectedValue),
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                QuantityPerUnit = tbxQuantityPerUnitUpdate.Text,
                UnitsInStock = Convert.ToInt16(tbxUnitInStockUpdate.Text),
            });
            MessageBox.Show("Ürün Güncellendi");
            LoadProducts();
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwProduct.CurrentRow;
            tbxProductNameUpdate.Text = row.Cells[2].Value.ToString();
            cbxCategoryUpdate.SelectedValue = row.Cells[1].Value;
            tbxUnitPriceUpdate.Text = row.Cells[3].Value.ToString();
            tbxQuantityPerUnitUpdate.Text = row.Cells[4].Value.ToString();
            tbxUnitInStockUpdate.Text = row.Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Burada Data grid view'de seçilmemiş bir satırı silmeye kalkarsa hata vermemesi için kontrol ekledik.
            if (dgwProduct.CurrentRow != null)
            {
                try
                {
                    _productService.ProrductDelete(new Product
                    {
                        ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)
                    });
                    MessageBox.Show("Ürün Silindi ");
                    LoadProducts();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            
        }
    }
}
