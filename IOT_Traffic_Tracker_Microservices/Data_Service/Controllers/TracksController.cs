using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProvider.Entities;
using DataProvider.Repositories;
using Data_Service.Services;

namespace Data_Service.Controllers
{
    [ApiController]
    [Route("data-service/tracks")]
    public class TracksController : Controller
    {
        private readonly ITrackRepository _repo;
        private readonly IGeoService _geoService;

        public TracksController(ITrackRepository repo, IGeoService geoService)
        {
            _repo = repo;
            _geoService = geoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> Get()
        {
            var result = await _repo.GetAllTracks();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Track>> Get(long id)
        {
            var track = await _repo.GetTrack(id);
            if (track == null)
                return new NotFoundResult();

            return new ObjectResult(track);
        }

        [HttpPost]
        public async Task<ActionResult<Track>> Post([FromBody] Track track)
        {
            track.Id = await _repo.GetNextId();
            track.AirDistance = _geoService.AirDistance((double)track.StartLat, (double)track.StartLng, (double)track.EndLat, (double)track.EndLng);
            await _repo.Create(track);
            return new OkObjectResult(track);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Track>> Put(long id, [FromBody] Track track)
        {
            var trackFromDb = await _repo.GetTrack(id);
            if (trackFromDb == null)
                return new NotFoundResult();
            track.Id = trackFromDb.Id;
            track.InternalId = trackFromDb.InternalId;
            await _repo.Update(track);
            return new OkObjectResult(track);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var post = await _repo.GetTrack(id);
            if (post == null)
                return new NotFoundResult();
            await _repo.Delete(id);
            return new OkResult();
        }

        [HttpPost("array-of-tracks")]
        public async Task<ActionResult> Post([FromBody] SetOfTracks setOfTracks)
        {
            foreach(var track in setOfTracks.Tracks)
            {
                track.Id = await _repo.GetNextId();
                track.AirDistance = _geoService.AirDistance((double)track.StartLat, (double)track.StartLng, (double)track.EndLat, (double)track.EndLng);
                await _repo.Create(track);
            }
            return  Ok("Tracks saved successfully!");
        }

        [HttpGet("max-speed/{maxSpeed}")]
        public async Task<ActionResult> GetTracks(int maxSpeed)
        {
            var result = await _repo.GetTracks(maxSpeed);
            if(result == null)
                return new NotFoundResult();
            return Ok(result);
        }

        [HttpGet("air-distance/{airDistance}")]
        public async Task<ActionResult> GetTracksAirDistanceCondition(int airDistance)
        {
            var result = await _repo.GetTrascksAirDistanceCondition(airDistance);
            if (result == null)
                return new NotFoundResult();
            return Ok(result);
        }
    }
}
