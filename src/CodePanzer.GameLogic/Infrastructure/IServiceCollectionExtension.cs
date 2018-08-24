using CodePanzer.GameLogic.Map.Generator;
using CodePanzer.GameLogic.Map.Modifyer;
using CodePanzer.GameLogic.PanzerFactory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Infrastructure
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddGameLogic(this IServiceCollection services)
        {
            services.AddTransient<IMapGenerator, FromFileMapGenerator>();
            services.AddTransient<IPanzerFactory, PanzerFactory.PanzerFactory>();
            services.AddTransient<IGameRound, GameRound>();
            services.AddTransient<IPanzerBuilderFactory, PanzerBuilderFactory>();
            services.AddTransient<IMapModifyer, MapModifyer>();
            services.AddTransient<IGame, Game>();

            return services;
        }
    }
}
