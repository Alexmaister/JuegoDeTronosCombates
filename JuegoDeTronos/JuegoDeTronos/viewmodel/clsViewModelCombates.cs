using JuegoDeTronos_DAT.entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuegoDeTronos_BL.logica;
using System.ComponentModel;
using JuegoDeTronos_DAL.manejadores;
using JuegoDeTronos_DAT.entidades_adaptadas;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace JuegoDeTronos.viewmodel
{
    public class clsViewModelCombates : INotifyPropertyChanged 
    {

        #region Constructor
       


        public clsViewModelCombates()
        {

           


            _combates = new ObservableCollection<clsCombate>();
            _luchadores = new ObservableCollection<clsLuchador>();
            _luchadores_contrincante1 = new ObservableCollection<clsLuchador>();
            _luchadores_contrincante2 = new ObservableCollection<clsLuchador>();

            try
            {
                _listados = new clsListadosBL();
                _insercciones = new clsInsercciones();

                _combates = _listados.obtenerCombates();
                _luchadores = _listados.obtenerLuchadores();
               _luchadores_aux = _listados.obtenerLuchadores();
            }
            catch (Exception e)
            {
                throw e;

            }



        }
        #endregion
        #region Propiedades

        //Deberian ser constantes de la clase
        const String cadenabasecasa = "ms-appx:///Assets/Images/Casas/";
        const String cadenabaseluchador = "ms-appx:///Assets/Images/Luchadores/";

        //BL
        private clsListadosBL _listados;
        private clsInsercciones _insercciones;
        //Combates
        private ObservableCollection<clsCombate> _combates;

        private clsCombate _combate_seleccionado;
        //Luchadores

        private ObservableCollection<clsLuchador> _luchadores;
        private ObservableCollection<clsLuchador> _luchadores_aux;

        private ObservableCollection<clsLuchador> _luchadores_contrincante1;
        private ObservableCollection<clsLuchador> _luchadores_contrincante2;

        private clsLuchador _contrincante1, _contrincante2;


        private int sangriento,espectacular,victorioso;
        private bool _sangriento1, _sangriento2, _espectacular1, _espectacular2, _victorioso1, _victorioso2;
        public bool sangriento1 {
            get {
                return this._sangriento1;
            }
            set { this._sangriento1 = value;
                NotifyPropertyChanged("sangriento1");
                if (_sangriento1) sangriento = 1;else sangriento=2;
                _guardar_combate.RaiseCanExecuteChanged();
            }

        }

        public bool sangriento2 {

            get
            {
                return this._sangriento2;
            }
            set
            {
                this._sangriento2 = value;
                NotifyPropertyChanged("sangriento2");
                if (_sangriento2) sangriento = 2; else sangriento = 1;
                _guardar_combate.RaiseCanExecuteChanged();
            }
        }

        public bool espectacular1 {

            get
            {
                return this._espectacular1;
            }
            set
            {
                this._espectacular1 = value;
                NotifyPropertyChanged("espectacular1");
                if (_espectacular1) espectacular = 1; else espectacular =2;
                _guardar_combate.RaiseCanExecuteChanged();
            }
        }

        public bool espectacular2
        {

            get
            {
                return this._espectacular2;
            }
            set
            {
                this._espectacular2 = value;
                NotifyPropertyChanged("espectacular2");
                if (_espectacular2) espectacular = 2; else espectacular = 1;
                _guardar_combate.RaiseCanExecuteChanged();
            }
        }

        public bool victorioso1
        {

            get
            {
                return this._victorioso1;
            }
            set
            {
                this._victorioso1 = value;
                NotifyPropertyChanged("victorioso1");
                if (_victorioso1) victorioso = 1; else victorioso =2;
                _guardar_combate.RaiseCanExecuteChanged();
            }
        }
        public bool victorioso2
        {

            get
            {
                return this._victorioso2;
            }
            set
            {
                this._victorioso2 = value;
                NotifyPropertyChanged("victorioso2");
                if (_victorioso1) victorioso = 2; else victorioso = 1;
                _guardar_combate.RaiseCanExecuteChanged();
            }
        }
       

        //este comando hara que aparezcan las fotos y datos d elos contrincantes
        private DelegateCommand _combatir;
        public DelegateCommand combatir {

            get
            {
                _combatir = new DelegateCommand(Combatir, puede_combatir);
                return _combatir;
            }
        }

        private DelegateCommand _guardar_combate;
        public DelegateCommand guardar_combate
        {

            get
            {
                _guardar_combate = new DelegateCommand(Guardar, puede_guardar);
                return _guardar_combate;
            }
        }



        //Cadenas para bindear al source de foto

        private Uri _fotol1;
        private Uri _fotol2;
        private Uri _fotoc1;
        private Uri _fotoc2;
        public Uri fotol1 { get { return this._fotol1; }
            set { this._fotol1 = value;
                NotifyPropertyChanged ("fotol1");
            } }
        public Uri fotoc1 {
            get { return this._fotoc1; }
            set
            {
                this._fotoc1 = value;
                NotifyPropertyChanged("fotoc1");
            }
        }
        public Uri fotol2 {
            get { return this._fotol2; }
            set
            {
                this._fotol2 = value;
                NotifyPropertyChanged("fotol2");
            }
        }
        public Uri fotoc2 {
            get { return this._fotoc2; }
            set
            {
                this._fotoc2 = value;
                NotifyPropertyChanged("fotoc2");
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region PropiedadesPublicas


        public ObservableCollection<clsCombate> combates
        {

            get { return this._combates; }

            set
            {
                this._combates = value;
                NotifyPropertyChanged("combates");
            }
        }

        public clsCombate combate_seleccionado
        {

            get { return this._combate_seleccionado; }

            set
            {
                this._combate_seleccionado = value;

                NotifyPropertyChanged("combate_seleccionado");
                _luchadores_contrincante1 = _luchadores;
                NotifyPropertyChanged("luchadores_contrincante1");
                limpiarCombate();

               
            }
        }


        public ObservableCollection<clsLuchador> luchadores
        {
            get { return this._luchadores; }
            set { this._luchadores = value;
                NotifyPropertyChanged("luchadores");
            }
        }


        public ObservableCollection<clsLuchador> luchadores_contrincante1
        {

            get { return this._luchadores_contrincante1; }

            set
            {
                this._luchadores_contrincante1 = value;
                NotifyPropertyChanged("luchadores_contrincante1");
            }
        }
        public ObservableCollection<clsLuchador> luchadores_contrincante2
        {

            get { return this._luchadores_contrincante2; }

            set
            {
                this._luchadores_contrincante2 = value;
                NotifyPropertyChanged("luchadores_contrincante2");
            }
        }

        public clsLuchador contrincante1
        {
            get { return this._contrincante1; }
            set
            {
                this._contrincante1 = value;
                NotifyPropertyChanged("contrincante1");
                if (contrincante1 != null)
                {
                    _luchadores_contrincante2 = _listados.obtenerLuchadores();
                    _luchadores_contrincante2.RemoveAt(_contrincante1.id - 1);
                }
                
                
                NotifyPropertyChanged("luchadores_contrincante2");
            }
        }

        public clsLuchador contrincante2
        {
            get { return this._contrincante2; }
            set
            {
                this._contrincante2 = value;
                NotifyPropertyChanged("contrincante2");
               _combatir.RaiseCanExecuteChanged();
             
            }
        }
        #endregion


        /// <summary>
        /// Procedimiento que establecera a los dos contrincantes , sus fotos y datos en pantalla
        /// </summary>
        private void Combatir() {
            
            //aqui metere fotos y nombre jugadores en campos correspondientes
            fotol1=new Uri(cadenabaseluchador+contrincante1.id+".jpg");
            fotoc1= new Uri(cadenabasecasa +contrincante1.id_casa+".png");
            fotol2= new Uri(cadenabaseluchador + contrincante2.id +".jpg");
            fotoc2 = new Uri(cadenabasecasa + contrincante2.id_casa + ".png");
            NotifyPropertyChanged("fotol1");
            NotifyPropertyChanged("fotoc1");
            NotifyPropertyChanged("fotol2");
            NotifyPropertyChanged("fotoc2");
            _guardar_combate.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Procedimiento que dira si se puede combatir o no
        /// </summary>
        /// <returns>Dato logico</returns>
        private bool puede_combatir() {

            return (contrincante1 != null && contrincante2 != null);
        }


        private void Guardar() {


            var c1 = new clsLuchadorClasificado(contrincante1.id, contrincante1.nombre, contrincante1.id_casa);

            var c2 = new clsLuchadorClasificado(contrincante2.id, contrincante2.nombre, contrincante2.id_casa);

            switch (sangriento) {

                case 1:

                    c1.sangriento = 10;
                    c2.sangriento = 5;
                    break;

                case 2:
                    c1.sangriento = 5;
                    c2.sangriento = 10;
                    break;

            }

            switch (espectacular)
            {

                case 1:

                    c1.espectacular = 10;
                    c2.espectacular = 5;
                    break;

                case 2:
                    c1.espectacular = 5;
                    c2.espectacular = 10;
                    break;

            }
            switch (victorioso)
            {

                case 1:

                    c1.vistorioso = 10;
                    c2.vistorioso = 5;
                    break;

                case 2:
                    c1.vistorioso = 5;
                    c2.vistorioso = 10;
                    break;

            }


            _insercciones.insertarClasificacionCombate(combate_seleccionado, c1, c2);

            _combates.Remove(_combate_seleccionado);
            NotifyPropertyChanged("combates");

        }
        /// <summary>
        /// Funcion que dira si se puede guardar o no
        /// </summary>
        /// <returns></returns>
        private bool puede_guardar() {

            return (contrincante1!=null && contrincante2!=null && fotol1!=null && (_sangriento1 != _sangriento2 && _espectacular1 != _espectacular2 && victorioso1 != _victorioso2));
        }

        /// <summary>
        /// Procedfimiento que quitara los datos de pantalla al cambiar de combate
        /// </summary>
        private void limpiarCombate() {

            contrincante1 = null; NotifyPropertyChanged("contrincante1");
            contrincante2 = null; NotifyPropertyChanged("contrincante2");
            _luchadores_contrincante2 = new ObservableCollection<clsLuchador>();
            NotifyPropertyChanged("luchadores_contrincante2");

            fotol1 = null;  NotifyPropertyChanged("fotol1");
            fotoc1 = null; NotifyPropertyChanged("fotoc1");
            fotol2 = null; NotifyPropertyChanged("fotol2");
            fotoc2 = null; NotifyPropertyChanged("fotoc2");

        }

        /*
        /// <summary>
        /// Funcion que recogera el valor del radio de los radio buton sangrientos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Sangriento(object sender, RoutedEventArgs e)
        {
            RadioButton b = (RadioButton)sender;
            sangriento = int.Parse((String)b.Tag);

        }

        /// <summary>
        /// Funcion que recogera el valor del radio de los radio buton sespectacular
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Espectacular(object sender, RoutedEventArgs e)
        {
            RadioButton b = (RadioButton)sender;
            espectacular = int.Parse((String)b.Tag);

        }

        /// <summary>
        /// Funcion que recogera el valor del radio de los radio buton victorioso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Victorioso(object sender, RoutedEventArgs e)
        {
            RadioButton b = (RadioButton)sender;
            victorioso = int.Parse((String)b.Tag);

        }
        */
    }
}

