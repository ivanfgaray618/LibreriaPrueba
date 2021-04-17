namespace FrontEnd
{
    using FrontEnd.Labels;
    using Model;
    using Negocio.Clases;
    using Negocio.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    /// <summary>
    /// Lógica de interacción para ModificarAutor.xaml
    /// </summary>
    public partial class ModificarAutor : Window
    {
        #region Constantes
        const string Nombre = "Nombre";
        const string IdPais = "IdPais";
        const string IdCiudad = "IdCiudad";
        const string IdSexo = "IdSexo";
        #endregion

        #region Variables
        private IAutorNegocio autorNegocio;
        private IEnumerable<Pais> listaPaises;
        private IEnumerable<Ciudad> listaCiudades;
        private IEnumerable<Sexo> listaGeneros;
        private Autor autor;
        #endregion

        #region Constructor
        public ModificarAutor(Autor autor)
        {
            InitializeComponent();
            this.EnlazarEventos();
            this.EstablecerDependencias();
            this.CargarPaises();
            this.CargarGeneros();
            this.MapearAutor(autor);
            this.autor = autor;
        }

        #endregion

        #region Métodos privados
        private void EnlazarEventos()
        {
            this.BtnModificarAutor.Click += BtnModificarLibroClick;
            this.txtNacionalidad.SelectionChanged += TxtNacionalidadSelectionChanged;
        }

        private void TxtNacionalidadSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.CargarCiudades();
        }

        private void BtnModificarLibroClick(object sender, RoutedEventArgs e)
        {
            Autor autor = new Autor();
            autor.IdAutor = this.autor.IdAutor;
            autor.Nombre = this.txtNombre.Text;
            autor.IdPais = Convert.ToInt32(this.txtNacionalidad.SelectedValue, CultureInfo.CurrentCulture);
            autor.IdCiudad = Convert.ToInt32(this.txtCiudad.SelectedValue, CultureInfo.CurrentCulture);
            autor.IdSexo = this.txtSexo.SelectedValue.ToString();
            var respuesta = this.autorNegocio.ModificarAutor(autor);
            MessageBox.Show(Application.Current.MainWindow, respuesta.NumeroError == default(int) ? LibrosEtiquetas.GuardadoCorrecto: LibrosEtiquetas.Error);
            this.Close();
        }

        private void EstablecerDependencias()
        {
            this.autorNegocio = new AutorNegocio();
            this.listaPaises = new List<Pais>();
            this.listaCiudades = new List<Ciudad>();
            this.listaGeneros = new List<Sexo>();
        }

        private void CargarPaises()
        {
            this.listaPaises = this.autorNegocio.ConsultarPaises();
            this.txtNacionalidad.ItemsSource = this.listaPaises;
            this.txtNacionalidad.DisplayMemberPath = Nombre;
            this.txtNacionalidad.SelectedValuePath = IdPais;
        }

        private void CargarCiudades()
        {
            this.listaCiudades = this.autorNegocio.ConsultarCiudades();
            this.txtCiudad.ItemsSource = this.listaCiudades.Where(ciudades => ciudades.IdPais == Convert.ToInt32(this.txtNacionalidad.SelectedValue));
            this.txtCiudad.DisplayMemberPath = Nombre;
            this.txtCiudad.SelectedValuePath = IdCiudad;
            this.txtCiudad.IsEnabled = true;
        }

        private void CargarGeneros()
        {
            this.listaGeneros = this.autorNegocio.ConsultarGeneros();
            this.txtSexo.ItemsSource = this.listaGeneros;
            this.txtSexo.DisplayMemberPath = Nombre;
            this.txtSexo.SelectedValuePath = IdSexo;
        }

        private void MapearAutor(Autor autor)
        {
            this.txtNombre.Text = autor.Nombre;
            this.txtNacionalidad.SelectedValue = autor.IdPais;
            this.txtCiudad.SelectedValue = autor.IdCiudad;
            this.txtSexo.SelectedValue = autor.IdSexo;
        }
        #endregion
    }
}
