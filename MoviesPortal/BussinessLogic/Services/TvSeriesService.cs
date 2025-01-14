﻿using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TvSeriesService : ITvSeriesService
    {
        private readonly TvSeriesRepository tvSeriesRepository;        

        public TvSeriesService(TvSeriesRepository tvSeriesRepository)
        {
            this.tvSeriesRepository = tvSeriesRepository;            
        }

        public async Task CreateNewSeries(TvSeriesModel tvSeries)
        {
            await tvSeriesRepository.Create(tvSeries);            
        }

        public async Task DeleteSeries(int id)
        {
            await tvSeriesRepository.Delete(id);
        }

        public async Task Edit(int id, TvSeriesModel tvSeries)
        {
            await tvSeriesRepository.Edit(id, tvSeries);
        }

        public async Task<IQueryable<TvSeriesModel>> GetAll()
        {
            return tvSeriesRepository.GetAll();
        }

        public async Task<TvSeriesModel> GetById(int id)
        {
            return await tvSeriesRepository.GetById(id);
        }
    }
}
