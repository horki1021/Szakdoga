using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SzamitogepNyilvantarto.Data.Entities;
using SzamitogepNyilvantarto.UI.DocumentGenerators;
using SzamitogepNyilvantarto.UI.Enums;

namespace SzamitogepNyilvantarto.UI.MenuControls.Reports
{
    public partial class IdoszakHibakForm : Form
    {
        public IdoszakHibakForm()
        {
            InitializeComponent();
            dateTimePickerKezdet.MaxDate=DateTime.Now;
            dateTimePickerVeg.MaxDate=DateTime.Now;
        }

        private void OnKezdetLeave(object sender, EventArgs e)
        {
            dateTimePickerVeg.MinDate = new DateTime(dateTimePickerKezdet.Value.Year, dateTimePickerKezdet.Value.Month, dateTimePickerKezdet.Value.Day-1);
        }
        
        private async void OnOKClick(object sender, EventArgs e)
        {
            using AppDbContext context = new AppDbContext();
            List<SzamitogepNyilvantarto.Data.Entities.Hiba> viewModel = context.Hibak.Include(x => x.Allapot)
                                                                                        .Include(x => x.HibasGep)
                                                                                        .ThenInclude(x => x.Allapot)
                                                                                        .Include(x => x.CsereGep)
                                                                                        .ThenInclude(x => x.Allapot)
                                                                                        .Where(x=>x.BejelentesDatum>=dateTimePickerKezdet.Value.Date || x.BejelentesDatum <= dateTimePickerVeg.Value.Date)
                                                                                        .ToList();
            if (!viewModel.Any())
            {
                MessageBox.Show("Az adott időszakon nincs hiba!", "Figyelem", MessageBoxButtons.OK);
                return;
            }
            try
            {
                string extension = context.Felhasznalok.First().DokumentumTipus;
                DocumentType type = extension == "pdf" ? DocumentType.PDF : DocumentType.DocX;
                IDocumentGenerator generator = DocumentGeneratorFactory.GetGeneratorType(type);
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fullPath = Path.Combine(path, $"Hibák {dateTimePickerKezdet.Value:yyyy.MM.dd}-{dateTimePickerVeg.Value:yyyy.MM.dd}.{extension}");
                await generator.GenerateDocumentAsync("IdoszakHibak", viewModel, fullPath);
                MessageBox.Show("A dokumentum generálása megtörtént.", "Figyelem", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("A dokumentum generálása sikertelen.", "Figyelem", MessageBoxButtons.OK);

            }
        }
    }
}
