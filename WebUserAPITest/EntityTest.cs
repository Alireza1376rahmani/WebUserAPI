using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Domain;
using Domain.builders;

namespace WebUserAPITest
{
    public abstract class EntityTest<TEntity,TBuilder> :IDisposable
        where TEntity:Entity
        where TBuilder:EntityBuilder<TEntity,TBuilder>
    {
        protected TEntity sut;
        protected TBuilder builder;
        protected const string SOME_ID = " {BC5ED16F-1A49-4034-AED8-5EC22B0F69D5}";
        protected const string SOME_STRING = "some string";

        public EntityTest()
        {
            builder = GetBuilderInstance();
            builder.WithId(Guid.Parse(SOME_ID));
           // sut = builder.Build();
        }

        protected virtual void AssertInvariants()
        {
             Assert.Equal(Guid.Parse(SOME_ID), sut.Id);
        }

        //protected abstract TEntity GetInstance();
        protected abstract TBuilder GetBuilderInstance();

        [Fact]
        public void Constructor_MustCreateCorrectEntity()
        {
            #region Arrange
            #endregion

            #region Act
            sut = builder.Build();
            #endregion

            #region Assert
            #endregion
        }

        public void Dispose()
        {
            if (sut == null) return;
            AssertInvariants();
        }
    }
}
