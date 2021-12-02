using System;
using NUnit.Framework;

namespace TEST.Editor
{
    public class TournamentJsonDeserializer_TEST
    {
        [Test]
        public void Test_Deserializer()
        {
            string json = @"{
                              'data': [
                                {
                                  'type': 'tournament',
                                  'id': 'eu-fls7',
                                  'attributes': {
                                    'createdAt': '2021-11-28T12:46:24Z'
                                  }
                                },
                                {
                                  'type': 'tournament',
                                  'id': 'as-pgcwf1',
                                  'attributes': {
                                    'createdAt': '2021-11-27T10:38:04Z'
                                  }
                                }
	                            ],
	                            'links': {
                                'self': 'https://api.pubg.com/tournaments'
                              },
                              'meta': {}
                            }";

            var deserializer = new TournamentJsonDeserializer();
            var result = deserializer.Deserialize(json);

            DateTime dateTimeFirst = new DateTime(2021,11,28,12,46,24);
            DateTime dateTimeSecond = new DateTime(2021,11,27,10,38,04);
            
            Assert.AreEqual("eu-fls7",result.data[0].id);
            Assert.AreEqual(dateTimeFirst,result.data[0].attributes.createdAt);
            
            Assert.AreEqual("as-pgcwf1",result.data[1].id);
            Assert.AreEqual(dateTimeSecond,result.data[1].attributes.createdAt);
             
            
            
        }
    }
}