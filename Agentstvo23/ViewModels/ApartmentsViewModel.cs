using Agentstvo23.DAL.Context;
using Agentstvo23.DAL.Entities.Estates;
using Agentstvo23.Infrastructure.Commands;
using Agentstvo23.Services.Interfaces;
using Agentstvo23.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Agentstvo23.ViewModels
{
    internal class ApartmentsViewModel : ViewModel
    {
        private string _title = "Квартиры";
        private readonly IUserDialog UserDialog;
        private readonly RealEstateDB DataBase;

        public string Title { get => _title; set => Set(ref _title, value); }

        #region Apartments : ObservableCollection<Apartments> - коллекция квартир

        private ObservableCollection<Apartment> apartments;

        /// <summary> Коллекция книг </summary>
        public ObservableCollection<Apartment> ApartmentsList
        {
            get => apartments;
            set
            {
                if (Set(ref apartments, value))
                {
                    apartmentsViewSource = new CollectionViewSource
                    {
                        Source = value,
                        SortDescriptions =
                        {
                            new SortDescription(nameof(Apartment.Id), ListSortDirection.Ascending )
                        }
                    };

                    //apartmentsViewSource.Filter += OnBuildingFilter;
                    //apartmentsViewSource.Filter += OnAddressFilter;
                    //apartmentsViewSource.Filter += OnFloorFilter;
                    //apartmentsViewSource.Filter += OnUndergroundFloorFilter;
                    //apartmentsViewSource.Filter += OnCadastralBlockFilter;
                    //apartmentsViewSource.Filter += OnAssignationFilter;

                    apartmentsViewSource.View.Refresh();

                    OnPropertyChanged(nameof(ApartmentsView));
                }
            }
        }


        #endregion

        private CollectionViewSource apartmentsViewSource;

        public ICollectionView ApartmentsView => apartmentsViewSource?.View;

        private Apartment selectedApartment;
        public Apartment SelectedApartment { get => selectedApartment; set => Set(ref selectedApartment, value); }



        #region Commands
        private ICommand _LoadedAsync;
        public ICommand LoadedAsyncCmd => _LoadedAsync
            ??= new LambdaCommand(LoadedAsyncExecuted);
        private void LoadedAsyncExecuted()
        {
            LoadAsync();
        } 
        #endregion


        public ApartmentsViewModel(RealEstateDB db, IUserDialog userDialog)
        {
            DataBase = db;
            UserDialog = userDialog;
        }

        private void LoadAsync()
        {
            DataBase.Apartments.Load();
            ApartmentsList = DataBase.Apartments.Local.ToObservableCollection();
        }
    }
}
