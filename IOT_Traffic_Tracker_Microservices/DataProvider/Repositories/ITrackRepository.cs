using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Entities;

namespace DataProvider.Repositories
{
    public interface ITrackRepository
    {
        Task<IEnumerable<Track>> GetAllTracks();
        Task<Track> GetTrack(long id);
        Task Create(Track track);
        Task<bool> Update(Track track);
        Task<bool> Delete(long id);
        Task<long> GetNextId();
        Task<IEnumerable<Track>> GetTracks(int maxSpeed);
        Task<IEnumerable<Track>> GetTrascksAirDistanceCondition(int airDistance);
    }
}
