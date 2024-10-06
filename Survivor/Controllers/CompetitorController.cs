using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survivor.Data;
using Survivor.Dtos;
using Survivor.Entities;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
        private readonly SurvivorContext _context;

        public CompetitorController(SurvivorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitorDto>>> GetCompetitors()
        {
            var competitors = await _context.Competitors
                .Include(c => c.Category)
                .ToListAsync();

            var competitorDtos = competitors.Select(c => new CompetitorDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                CategoryId = c.CategoryId,
                CategoryName = c.Category.Name
            }).ToList();

            return Ok(competitorDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitorDto>> GetCompetitor(int id)
        {
            var competitor = await _context.Competitors
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (competitor == null)
            {
                return NotFound();
            }

            var competitorDto = new CompetitorDto
            {
                Id = competitor.Id,
                FirstName = competitor.FirstName,
                LastName = competitor.LastName,
                CategoryId = competitor.CategoryId,
                CategoryName = competitor.Category.Name
            };

            return Ok(competitorDto);
        }

        [HttpGet("categories/{categoryId}")]
        public async Task<ActionResult<IEnumerable<CompetitorDto>>> GetCompetitorsByCategory(int categoryId)
        {
            var competitors = await _context.Competitors
                .Include(c => c.Category)
                .Where(c => c.CategoryId == categoryId)
                .ToListAsync();

            if (!competitors.Any())
            {
                return NotFound();
            }

            var competitorDtos = competitors.Select(c => new CompetitorDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                CategoryId = c.CategoryId,
                CategoryName = c.Category.Name
            }).ToList();

            return Ok(competitorDtos);
        }

        [HttpPost]
        public async Task<ActionResult<CompetitorDto>> PostCompetitor(CreateCompetitorDto competitorDto)
        {
            var category = await _context.Categories.FindAsync(competitorDto.CategoryId);
            if (category == null)
            {
                return BadRequest("Invalid CategoryId");
            }

            var competitor = new Competitor
            {
                FirstName = competitorDto.FirstName,
                LastName = competitorDto.LastName,
                CategoryId = competitorDto.CategoryId
            };

            _context.Competitors.Add(competitor);
            await _context.SaveChangesAsync();

            var createdCompetitorDto = new CompetitorDto
            {
                Id = competitor.Id,
                FirstName = competitor.FirstName,
                LastName = competitor.LastName,
                CategoryId = competitor.CategoryId,
                CategoryName = category.Name
            };

            return CreatedAtAction(nameof(GetCompetitor), new { id = competitor.Id }, createdCompetitorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetitor(int id, UpdateCompetitorDto competitorDto)
        {
            var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(competitorDto.CategoryId);
            if (category == null)
            {
                return BadRequest("Invalid CategoryId");
            }

            competitor.FirstName = competitorDto.FirstName;
            competitor.LastName = competitorDto.LastName;
            competitor.CategoryId = competitorDto.CategoryId;

            _context.Entry(competitor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitor(int id)
        {
            var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null)
            {
                return NotFound();
            }

            _context.Competitors.Remove(competitor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
