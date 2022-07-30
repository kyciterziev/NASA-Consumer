using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NasaConsumer.Interfaces;
using NasaConsumer.Models;

namespace NasaConsumer.Controllers;

public class NasaController : Controller
{
    private readonly ILogger<NasaController> _logger;
    private readonly INasaViewModelService _nasaViewModelService;
    private readonly INasaService _nasaService;

    public NasaController(ILogger<NasaController> logger, INasaViewModelService nasaViewModelService, INasaService nasaService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _nasaViewModelService = nasaViewModelService ?? throw new ArgumentNullException(nameof(nasaViewModelService));
        _nasaService = nasaService ?? throw new ArgumentNullException(nameof(nasaService));
    }

    [HttpGet("asteroids")]
    public async Task<IActionResult> GetAsteroids(AsteroidsViewModel request)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var asteroidsViewModel = await _nasaViewModelService.GetAsteroidsByDateRangeAsync(request.StartDate, request.EndDate);

        return View(asteroidsViewModel);
    }

    [HttpGet("pic-of-the-day")]
    public async Task<IActionResult> PicOfTheDay(PicsOfTheDayViewModel request)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var picsViewModels = await _nasaViewModelService.GetPicsOfTheDayAsync(request.StartDate, request.EndDate);

        return View(new PicsOfTheDayViewModel
        {
            PicsOfTheDayViewModels = picsViewModels
        });
    }

    [HttpGet("export-excel")]
    public async Task<IActionResult> DownloadExcel(ExportExcelViewModel request)
    {
        var asteroidsByteData = await _nasaService.GetAsteroidsExcelDataToByteArrayAsync(request.StartDate, request.EndDate);
        return File(asteroidsByteData, MediaTypeNames.Application.Octet, "nasa-asteroids.xlsx");
    }
}
