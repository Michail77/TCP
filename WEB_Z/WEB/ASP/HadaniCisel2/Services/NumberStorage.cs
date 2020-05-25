using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HadaniCisel2.Models;
using HadaniCisel2.Services;
using Microsoft.AspNetCore.Http;
using Utf8Json;
using Utf8Json.Resolvers;

namespace HadaniCisel2.Services
{
    public class NumberStorage
    {
        private Random _rand;
        private IHttpContextAccessor _accessor;
        private ISession _session;
        
        public NumberStorage(IHttpContextAccessor accessor)
        {
            _rand = new Random();
            State = new NumberGuessState();
            _accessor = accessor;
            _session = _accessor.HttpContext.Session;
            Generate(10);
        }

        public void Load()
        {
            JsonSerializer.SetDefaultResolver(StandardResolver.AllowPrivateCamelCase);
            State = JsonSerializer.Deserialize<NumberGuessState>(_session.GetString("ng"));
        }

        public void Save()
        {
            _session.Set("ng",JsonSerializer.Serialize(State));
        }
        

        public void Generate(int range)
        {
            State.GuessedNumber = _rand.Next(range);
            State.Attempt = 0;
            State.State = GameState.Running;
            State.Limit = range;
        }

        public int Guess(int number)
        {
            if (number < State.GuessedNumber) return 1;
            if (number > State.GuessedNumber) return -1;
            State.State = GameState.Won;
            return 0;
        }

        public void Restart()
        {
            Generate(10);
        }
        public NumberGuessState State { get; set; }
    }
}