using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataProvider.Entities;
using DataProvider.Config;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;

namespace DataProvider.Repositories
{
    public class TrackRepository: ITrackRepository
    {
        private readonly IMongoCollection<Track> _tracks;
        public TrackRepository(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tracks = database.GetCollection<Track>(settings.TracksCollectionName);
        }

        public async Task<IEnumerable<Track>> GetAllTracks()
        {
            return await _tracks
                          .Find(_ => true)
                          .ToListAsync();
        }

        
        public Task<Track> GetTrack(long id)
        {
            FilterDefinition<Track> filter = Builders<Track>.Filter.Eq(m => m.Id, id);

            return _tracks
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(Track track)
        {
            await _tracks.InsertOneAsync(track);
        }

        public async Task<bool> Update(Track track)
        {
            ReplaceOneResult updateResult =
                await _tracks
                        .ReplaceOneAsync(
                            filter: g => g.Id == track.Id,
                            replacement: track);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(long id)
        {
            FilterDefinition<Track> filter = Builders<Track>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _tracks
                                              .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<long> GetNextId()
        {
            return await _tracks.CountDocumentsAsync(new BsonDocument()) + 1;
        }

        public async Task<IEnumerable<Track>> GetTracks(int maxSpeed)
        {
            FilterDefinition<Track> filter = Builders<Track>.Filter.Gt(m => m.Speed, maxSpeed);

            return await _tracks.Find(filter)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetTrascksAirDistanceCondition(int airDistance)
        {
            FilterDefinition<Track> filter = Builders<Track>.Filter.Lte(t => t.AirDistance, airDistance);

            return await _tracks.Find(filter)
                   .ToListAsync();
        }
    }
}
