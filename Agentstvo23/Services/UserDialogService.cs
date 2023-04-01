using Agentstvo23.DAL.Entities.Estates;
using Agentstvo23.Services.Interfaces;
using Agentstvo23.ViewModels;
using Agentstvo23.Views.Windows;
using System.Windows;

namespace Agentstvo23.Services
{
    internal class UserDialogService : IUserDialog
    {
        public bool Edit(Building? building)
        {
            if (building == null) return false;
            var building_editor_model = new BuildingEditorViewModel(building);
            var building_editor_window = new BuildingEditorWindow()
            {
                DataContext = building_editor_model
            };

            if (building_editor_window.ShowDialog() != true) return false;

            building.CadastralNumber = building_editor_model.CadastralNumber;
            building.Adress = building_editor_model.Address;
            building.Area = building_editor_model.Area;
            building.CadastralCostValue = building_editor_model.CadastralCost;
            building.CostPerMeter = building_editor_model.CadastralCostPerMeter;
            building.AssignationBuilding = building_editor_model.AssignationBuilding;
            building.CadastralBlock = building_editor_model.CadastralBlock;
            building.YearBuilt = building_editor_model.YearBuilt;
            building.Floors = building_editor_model.Floors;
            building.UndergroundFloors = building_editor_model.UndergroundFloors;

            return true;
        }

        public bool ConfirmedInforamtion(string Information, string Caption) => MessageBox
            .Show(
            Information, Caption,
            MessageBoxButton.YesNo, 
            MessageBoxImage.Information) 
            == MessageBoxResult.Yes;

        public bool ConfirmError(string Error, string Caption) => MessageBox
             .Show(
            Error, Caption,
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning)
            == MessageBoxResult.Yes;

        public bool ConfirmWarning(string Warning, string Caption) => MessageBox
             .Show(
            Warning, Caption,
            MessageBoxButton.YesNo,
            MessageBoxImage.Error)
            == MessageBoxResult.Yes;

    }
}
