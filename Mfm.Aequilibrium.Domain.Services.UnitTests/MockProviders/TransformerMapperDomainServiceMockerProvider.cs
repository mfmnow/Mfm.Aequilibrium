using Mfm.Aequilibrium.Data.Entities;
using Mfm.Aequilibrium.Domain.Models;
using System;

namespace Mfm.Aequilibrium.Domain.Services.UnitTests.MockProviders
{
    internal class TransformerMapperDomainServiceMockerProvider
    {
        public static DateTime Now = DateTime.Now;
        public static TransformerEntity MockedTransformerEntity = new TransformerEntity
        {
            Courage = 1,
            CreatedBy = "CreatedBy",
            CreatedDate = Now,
            Endurance = 2,
            Firepower = 3,
            Id = 4,
            Intelligence = 5,
            LastModifiedBy = "LastModifiedBy",
            LastModifiedDate = Now.AddDays(1),
            Name = "Name",
            OverallRating = 6,
            Rank = 7,
            Skill = 8,
            Speed = 9,
            Strength = 10,
            Type = 1
        };
        public static TransformerDisplayModel ExpectedTransformerDisplayModel = new TransformerDisplayModel
        {
            Courage = 1,
            Endurance = 2,
            Firepower = 3,
            Id = 4,
            Intelligence = 5,
            Name = "Name",
            OverallRating = 6,
            Rank = 7,
            Skill = 8,
            Speed = 9,
            Strength = 10,
            Type = 'A',
            TypeEnum = Models.Enums.TransformerType.A
        };
    }
}
