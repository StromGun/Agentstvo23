using Agentstvo23.DAL.Entities;
using Agentstvo23.ViewModels.Base;
using Microsoft.IdentityModel.Tokens;
using System;
using System.ComponentModel;

namespace Agentstvo23.ViewModels
{
    internal class BuildingEditorViewModel : ViewModel, IDataErrorInfo
    {
        private string _title = "Editor";

        private string _cadastralNumber;
        private string _address;
        private double _area;
        private decimal _cadastralCost;
        private decimal _cadastralCostPerMeter;
        private string _assignationBuilding;
        private string _cadastralBlock;
        private int _yearBuilt;
        private int _floors;
        private int? _undergroundFloors;


        #region Properties
        public int Id { get; }
        public string Title { get => _title; set => Set(ref _title, value); }
        public string Address { get => _address; set => Set(ref _address, value); }
        public double Area { get => _area; set => Set(ref _area, value); }
        public string AssignationBuilding { get => _assignationBuilding; set => Set(ref _assignationBuilding, value); }
        public decimal CadastralCost { get => _cadastralCost; set => Set(ref _cadastralCost, value); }
        public decimal CadastralCostPerMeter { get => _cadastralCostPerMeter; set => Set(ref _cadastralCostPerMeter, value); }
        public int Floors { get => _floors; set => Set(ref _floors, value); }
        public int? UndergroundFloors { get => _undergroundFloors; set => Set(ref _undergroundFloors, value); }
        public string CadastralNumber { get => _cadastralNumber; set => Set(ref _cadastralNumber, value); }
        public string CadastralBlock { get => _cadastralBlock; set => Set(ref _cadastralBlock, value); }
        public int YearBuilt { get => _yearBuilt; set => Set(ref _yearBuilt, value); }

        #endregion


        public BuildingEditorViewModel(Building building)
        {
            Id = building.Id;
            Address = building.Adress;
            Area = building.Area;
            AssignationBuilding = building.AssignationBuilding;
            CadastralCost = building.CadastralCostValue;
            CadastralCostPerMeter = building.CostPerMeter;
            Floors = building.Floors;
            UndergroundFloors = building.UndergroundFloors;
            CadastralNumber = building.CadastralNumber;
            CadastralBlock = building.CadastralBlock;
            YearBuilt = building.YearBuilt;
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Address":
                        if (Address.IsNullOrEmpty())
                            error = "Пустое поле";
                        break;
                    case "Area":
                        if (Area < 0)
                            error = "Не может быть меньше 0";
                        break;
                    case "AssignationBuilding":
                        if (AssignationBuilding.IsNullOrEmpty())
                            error = "Пустое поле";
                        break;
                    case "CadastralCost":
                        if (CadastralCost < 0)
                            error = "Не может быть меньше 0";
                        break;
                    case "CadastralCostPerMeter":
                        if (CadastralCostPerMeter < 0)
                            error = "Не может быть меньше 0";
                        break;
                    case "Floors":
                        if (Floors < 0)
                            error = "Не может быть меньше 0";
                        break;
                    case "CadastralNumber":
                        if (CadastralNumber.IsNullOrEmpty())
                            error = "Пустое поле";
                        break;
                    case "CadastralBlock":
                        if (CadastralBlock.IsNullOrEmpty())
                            error = "Пустое поле";
                        break;
                    case "YearBuilt":
                        if (YearBuilt < 0)
                            error = "Не может быть меньше 0";
                        break;

                }
                return error;
            }
        }


        public string Error => throw new System.NotImplementedException();
    }
}
