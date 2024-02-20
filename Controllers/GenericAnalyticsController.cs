using Microsoft.AspNetCore.Mvc;
using QualityLabPro.Api.GenericAnalytics;
using QualityLabPro.Api.Services;

namespace QualityLabPro.Api.Controllers;
[Route("api/[controller]")]
public class GenericAnalyticsController : ControllerBase
{
    private readonly IGenericAnalyticsService _genericAnalyticsService;

    public GenericAnalyticsController(IGenericAnalyticsService genericAnalyticsService)
    {
        _genericAnalyticsService = genericAnalyticsService;
    }

    [HttpGet]
    public IActionResult GetGenericAnalytics()
    {
        var analytics = _genericAnalyticsService.GetAllGenericAnalytics();
        return Ok(analytics);
    }
    
    
    [HttpGet("{guid}")]
    public IActionResult GetGenericAnalyticsById(Guid guid)
    {
        var analytics = _genericAnalyticsService.GetGenericAnalyticsById(guid);
        if (analytics != null)
        {
            return Ok(analytics);
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult SendGenericAnalytics(GenericAnalyticsRecord genericAnalyticsRecord)
    {
        var analytics = new Entities.GenericAnalytics(genericAnalyticsRecord.date, genericAnalyticsRecord.level,
            genericAnalyticsRecord.level_lot, genericAnalyticsRecord.test_lot, genericAnalyticsRecord.name,
            genericAnalyticsRecord.value, genericAnalyticsRecord.mean, genericAnalyticsRecord.sd,
            genericAnalyticsRecord.unit_value);

        _genericAnalyticsService.CreateGenericAnalytics(analytics);
        return CreatedAtAction(nameof(GetGenericAnalyticsById), new { id = analytics.Id }, analytics);
    }
    
    [HttpPost("list")]
    public IActionResult SendGenericAnalyticsList([FromBody] List<GenericAnalyticsRecord> genericAnalyticsRecords)
    {
        var analyticsList = genericAnalyticsRecords.Select(record => new Entities.GenericAnalytics(
            record.date,
            record.level, 
            record.level_lot,
            record.test_lot,
            record.name,
            record.value,
            record.mean,
            record.sd,
            record.unit_value
        )).ToList();

        _genericAnalyticsService.CreateGenericAnalyticsList(analyticsList);

        return Ok();
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateAnalytics(Guid id, GenericAnalyticsRecord genericAnalyticsRecord)
    {
        var oldAnalytics = _genericAnalyticsService.GetGenericAnalyticsById(id);
        var newAnalytics = new Entities.GenericAnalytics(genericAnalyticsRecord.date, genericAnalyticsRecord.level,
            genericAnalyticsRecord.level_lot, genericAnalyticsRecord.test_lot, genericAnalyticsRecord.name,
            genericAnalyticsRecord.value, genericAnalyticsRecord.mean, genericAnalyticsRecord.sd,
            genericAnalyticsRecord.unit_value);
       
        if (oldAnalytics == null)
        {
            return NotFound();
        }
        _genericAnalyticsService.UpdateGenericAnalyticsById(id, newAnalytics);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteAnalytics(Guid id)
    {       
        _genericAnalyticsService.DeleteAnalytics(id);

        return NoContent();
    }
}