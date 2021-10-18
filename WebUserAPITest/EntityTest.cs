using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Domain;

namespace WebUserAPITest
{
    public abstract class EntityTest<TEntity> :IDisposable
        where TEntity:Entity
    {
        protected TEntity sut;
        protected const string SOME_ID = " {BC5ED16F-1A49-4034-AED8-5EC22B0F69D5}";
        protected const string SOME_STRING = "some string";
        public EntityTest()
        {
            sut = GetInstance();
        }

        protected virtual void AssertInvariants()
        {
             Assert.Equal(Guid.Parse(SOME_ID), sut.Id);
        }

        protected abstract TEntity GetInstance();

        [Fact]
        public void Constructor_MustCreateCorrectEntity()
        {
            #region Arrange
            #endregion

            #region Act
            sut = GetInstance();
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
