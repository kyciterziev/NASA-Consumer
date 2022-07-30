using NasaConsumer.Clients;
using NasaConsumer.Clients.Models;
using NasaConsumer.Interfaces;
using OfficeOpenXml;

namespace NasaConsumer.Services
{
    public class NasaService : INasaService
    {
        private readonly INasaClient _nasaClient;

        public NasaService(INasaClient nasaClient)
        {
            _nasaClient = nasaClient ?? throw new ArgumentNullException(nameof(nasaClient));
        }

        public async Task<AsteroidsResponse> GetAsteroidsByDateRangeAsync(DateTime startDate, DateTime? endDate)
        {
            return await _nasaClient.GetAsteroidsByDateRangeAsync(startDate, endDate);
        }

        public async Task<byte[]> GetAsteroidsExcelDataToByteArrayAsync(DateTime startDate, DateTime? endDate)
        {
            var excelPackage = new ExcelPackage();

            var asteroids = await GetAsteroidsByDateRangeAsync(startDate, endDate);

            foreach (var currObject in asteroids.NearEarthObjects)
            {
                ExcelWorksheet Sheet = excelPackage.Workbook.Worksheets.Add($"Date: {currObject.Key}");
                Sheet.Cells["A1"].Value = "Name";
                Sheet.Cells["B1"].Value = "Estimated Diameter";
                Sheet.Cells["C1"].Value = "Dangerous To Earth";
                Sheet.Cells["D1"].Value = "Close Aproach Date";
                Sheet.Cells["E1"].Value = "Miss Distance";
                Sheet.Cells["F1"].Value = "Orbiting Body";
                int row = 2;
                foreach (var currObjVal in currObject.Value)
                {
                    var objCloseAppData = currObjVal.CloseApproachData.FirstOrDefault();

                    Sheet.Cells[$"A{row}"].Value = currObjVal.Name;
                    Sheet.Cells[$"B{row}"].Value = currObjVal.EstimatedDiameter.Kilometers.EstimatedDiameterMax;
                    Sheet.Cells[$"C{row}"].Value = currObjVal.IsPotentiallyHazardousAsteroid ? "Yes" : "No";
                    Sheet.Cells[$"D{row}"].Value = objCloseAppData?.CloseApproachDateFull;
                    Sheet.Cells[$"E{row}"].Value = objCloseAppData?.MissDistance.Kilometers;
                    Sheet.Cells[$"F{row}"].Value = objCloseAppData?.OrbitingBody;
                    row++;
                }
            }

            return await excelPackage.GetAsByteArrayAsync();
        }
    }
}