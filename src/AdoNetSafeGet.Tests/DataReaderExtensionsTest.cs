using Moq;
using System;
using System.Data;
using Xunit;

namespace AdoNetSafeGet.Tests
{
    public class DataReaderExtensionsTest : IDisposable
    {
        IDataReader _mockDataReader;
        public DataReaderExtensionsTest()
        {
           _mockDataReader = CreateMockDataReader().Object;
        }

        private Mock<IDataReader> CreateMockDataReader()
        {
            var mockdataReader = new Mock<IDataReader>();
            mockdataReader.Setup(m => m.FieldCount).Returns(10);
            mockdataReader.Setup(m => m.GetOrdinal("Int16Column")).Returns(0);
            mockdataReader.Setup(m => m.GetInt16(0)).Returns(Int16.MaxValue);
            mockdataReader.Setup(m => m.GetOrdinal("Int32Column")).Returns(1);
            mockdataReader.Setup(m => m.GetInt32(1)).Returns(Int32.MaxValue);
            mockdataReader.Setup(m => m.GetOrdinal("Int64Column")).Returns(2);
            mockdataReader.Setup(m => m.GetInt64(2)).Returns(Int64.MaxValue);
            mockdataReader.Setup(m => m.GetOrdinal("DecimalColumn")).Returns(3);
            mockdataReader.Setup(m => m.GetDecimal(3)).Returns(99.9m);
            mockdataReader.Setup(m => m.GetOrdinal("CharColumn")).Returns(4);
            mockdataReader.Setup(m => m.GetChar(4)).Returns('c');
            mockdataReader.Setup(m => m.GetOrdinal("ByteColumn")).Returns(5);
            mockdataReader.Setup(m => m.GetByte(5)).Returns(0x00C9);
            mockdataReader.Setup(m => m.GetOrdinal("StringColumn")).Returns(6);
            mockdataReader.Setup(m => m.GetString(6)).Returns("s");
            mockdataReader.Setup(m => m.GetOrdinal("DateTimeColumn")).Returns(7);
            mockdataReader.Setup(m => m.GetDateTime(7)).Returns(new DateTime(2017, 03, 20));
            mockdataReader.Setup(m => m.GetOrdinal("GuidColumn")).Returns(8);
            mockdataReader.Setup(m => m.GetGuid(8)).Returns(new Guid("a2934fa2-6f7e-4ac9-8210-681814ac86c4"));
            mockdataReader.SetupSequence(m => m.Read())
                .Returns(true);
            return mockdataReader;
        }

        [Fact]
        public void CallSafeGetMethodWithInvalidArgumentsColumnArgument_DataReartWithInt32Value_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _mockDataReader.SafeGetInt32(""));
            Assert.Throws<ArgumentException>(() => _mockDataReader.SafeGetInt32(" "));
            Assert.Throws<ArgumentException>(() => _mockDataReader.SafeGetInt32(null));
        }

        [Fact]
        public void SafeGetInt16_DataReaderWithInt16Value_ReturnInt16()
        {
            //Arrage
            Int16 expectedValue = Int16.MaxValue;
            Int16 realResult = default(Int16);
            var mockDataReader = _mockDataReader;
            
            //Act
            while (mockDataReader.Read())
            {
                realResult = mockDataReader.SafeGetInt16("Int16Column");
            }

            //Assert
            Assert.Equal(expectedValue, realResult);
        }

        [Fact]
        public void SafeGetInt32_DataReaderWithInt32Value_ReturnInt32()
        {
            //Arrage
            Int32 expectedValue = Int32.MaxValue;
            Int32 realResult = default(Int32);
            var mockDataReader = _mockDataReader;

            //Act
            while (mockDataReader.Read())
            {
                realResult = mockDataReader.SafeGetInt32("Int32Column");
            }

            //Assert
            Assert.Equal(expectedValue, realResult);
        }

        [Fact]
        public void SafeGetInt64_DataReaderWithInt64Value_ReturnInt64()
        {
            //Arrage
            Int64 expectedValue = Int64.MaxValue;
            Int64 realResult = default(Int64);
            var mockDataReader = _mockDataReader;

            //Act
            while (mockDataReader.Read())
            {
                realResult = mockDataReader.SafeGetInt64("Int64Column");
            }

            //Assert
            Assert.Equal(expectedValue, realResult);
        }

        [Fact]
        public void SafeGetDecimal_DataReaderWithDecimalValue_ReturnDecimal()
        {
            //Arrage
            Decimal expectedValue = 99.9m;
            Decimal realResult = default(Decimal);
            var mockDataReader = _mockDataReader;

            //Act
            while (mockDataReader.Read())
            {
                realResult = mockDataReader.SafeGetDecimal("DecimalColumn");
            }

            //Assert
            Assert.Equal(expectedValue, realResult);
        }

        [Fact]
        public void SafeGetChar_DataReaderWithCharValue_ReturnChar()
        {
            Char expectedResult = 'c';
            Char realResult = default(Char);
            var mockDataReader = _mockDataReader;

            while (mockDataReader.Read())
            {
                realResult = mockDataReader.SafeGetChar("CharColumn");
            }

            Assert.Equal(expectedResult, realResult);
        }

        [Fact]
        public void SafeGetByte_DataReaderWithByteValue_ReturnByte()
        {
            Byte expectedResult = 0x00C9;
            Byte realResult = default(Byte);

            var mockDataReader = _mockDataReader;

            while (mockDataReader.Read())
            {
                realResult = mockDataReader.SafeGetByte("ByteColumn");
            }

            Assert.Equal(expectedResult, realResult);

        }

        [Fact]
        public void SafeGetString_DataReaderWithStringValue_ReturnString()
        {
            String expectedResult = "s";
            String realResult = default(String);

            var mockDataReader = _mockDataReader;

            while (mockDataReader.Read())
            {
                realResult = mockDataReader.SafeGetString("StringColumn");
            }

            Assert.Equal(expectedResult, realResult);
        }

        [Fact]
        public void SafeGetDateTime_DataReaderWithDateTimeValue_ReturnDateTime()
        {
            DateTime expectedResult = new DateTime(2017, 03, 20);
            DateTime realResult = default(DateTime);

            var mockDataReader = _mockDataReader;

            while (mockDataReader.Read())
            {
                realResult = mockDataReader.SafeGetDateTime("DateTimeColumn");
            }

            Assert.Equal(expectedResult, realResult);
        }

        [Fact]
        public void SafeGetDateTimeAsFormatedString_DataReaderWithDateTimeValue_ReturnFormatedDateTimeString()
        {
            String dateTimeFormat = "yyyyMMddHHmmss";
            String expectedResult = new DateTime(2017, 03, 20).ToString(dateTimeFormat);
            String realResult = default(string);

            var mockDataReader = _mockDataReader;

            while (mockDataReader.Read())
            {
                realResult = mockDataReader.SafeGetDateTimeAsFormatedString("DateTimeColumn", DateTime.MinValue.ToString(), dateTimeFormat);
            }

            Assert.Equal(expectedResult, realResult);
        }

        [Fact]
        public void SafeGetGuid_DataReaderWithGuidValue_ReturnGuid()
        {
            Guid expectedGuid = new Guid("a2934fa2-6f7e-4ac9-8210-681814ac86c4");
            Guid realResult = default(Guid);

            var mockDataReader = _mockDataReader;

            while (mockDataReader.Read())
            {
                realResult = mockDataReader.SafeGetGuid("GuidColumn");
            }

            Assert.Equal(expectedGuid, realResult);
        }


        [Fact]
        public void GetStringColumnIndexByName_DataReaderWithStringColumn_ReturnIndex()
        {
            int expectedResult = 6;
            int realResult = default(int);
           
            var mockDataReader = _mockDataReader;

            realResult = mockDataReader.GetOrdinal("StringColumn");

            Assert.Equal(expectedResult, realResult);
        }

        public void Dispose()
        {
            _mockDataReader = null;
        }
    }
}
