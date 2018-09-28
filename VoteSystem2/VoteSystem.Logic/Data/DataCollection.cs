using System;
using System.Collections.Generic;
using VoteSystem.Logic.Models;

namespace VoteSystem.Logic.Data
{
    public static class DataCollection
    {
        public static List<User> Users { get; set; }
        public static List<Activity> VoteActivities { get; set; }
        public static List<Project> VoteProject { get; set; }
        public static List<Record> VoteRecords { get; set; }
        static DataCollection()
        {
            Users = new List<User>
            {
                new User{UserName="Jim",Password = "123456",UserID=1},
                new User{UserName="Anna", Password="456789",UserID=2},
                 new User{UserName="1", Password="1" ,UserID =3}
            };
            VoteActivities = new List<Activity>
            {
                 new Activity {
                     ActivityID=1,
                     ActivityIntroduction="这是最牛的比赛",
                     ActivityName="谁是计算大王",
                      StartTime=new DateTime(2016,7,12),
                      EndTime=new DateTime(2017,8,12)
                 },
                  new Activity {
                      ActivityID=2,
                     ActivityIntroduction="这是个激动人心的时刻",
                      ActivityName="左右手哪边最好用",
                      StartTime=new DateTime(2016,7,11),
                      EndTime=new DateTime(2017,8,12)
                 }
            };
            VoteProject = new List<Project>
            {
                 new Project {
                      ProjectName="小明",
                      ProjectIntroduction="那是一条神奇的犬的主人",
                      ProjectID=1,
                      ActivityID=1,
                      ActivityName="谁是计算机大王",
                      VoteNumber=20
                 },
                 new Project{
                     ProjectName="小聪",
                     ProjectIntroduction="他是一个好人",
                     ProjectID=2,
                     ActivityID=1,
                     ActivityName="谁是计算机大王",
                     VoteNumber=30
                 },
                  new Project{
                     ProjectName="小红",
                     ProjectIntroduction="她是一个美人",
                     ProjectID=3,
                     ActivityID=1,
                     ActivityName="谁是计算机大王",
                    VoteNumber=30
                  },
                   new Project{
                       ProjectName="左手",
                     ProjectIntroduction="用来吃饭，写字，梳头发",
                     ProjectID=1,
                     ActivityID=2,
                     ActivityName="左右手哪边最好用",
                     VoteNumber=30
                  },
                    new Project {
                       ProjectName="右手",
                     ProjectIntroduction="可以写字，吃饭，数钱",
                     ProjectID=2,
                     ActivityID=2,
                     ActivityName="左右手哪边最好用",
                     VoteNumber=30
                  }
            };
            VoteRecords = new List<Record>
            {
                new Record{
                     VoteTime=new DateTime(2016,7,18),
                     VoteUserName="A君",
                     ProjectID=1,
                     ActivityID=1,
                     ActivityName="谁是计算大王",
                     ProjectName="小明",
                     UserID=5
                },
                 new Record {
                     VoteTime=new DateTime(2016,7,18),
                     VoteUserName="Green",
                     ActivityID=1,
                     ProjectID=1,
                     ActivityName="谁是计算大王",
                     ProjectName="小明",
                     UserID=7
                },
                  new Record{
                     VoteTime=new DateTime(2016,7,18),
                     VoteUserName="1",
                     ProjectID=3,
                     ActivityID=1,
                     ActivityName="谁是计算大王",
                     ProjectName="小红",
                     UserID=3
                },
                 new Record{
                     VoteTime=new DateTime(2016,7,28),
                     VoteUserName="B君",
                     ProjectID=1,
                     ActivityID=1,
                     ActivityName="谁是计算大王",
                     ProjectName="小明",
                     UserID=11
                },
                  new Record{
                     VoteTime=new DateTime(2016,7,29),
                     VoteUserName="c君",
                     ProjectID=2,
                     ActivityID=1,
                     ActivityName="谁是计算大王",
                     ProjectName="小聪",
                     UserID=13
                },
                   new Record{
                     VoteTime=new DateTime(2016,7,29),
                     VoteUserName="d君",
                     ProjectID=2,
                     ActivityID=2,
                     ActivityName="左右手哪边最好用",
                     ProjectName="右手",
                     UserID=20
                },
                    new Record{
                     VoteTime=new DateTime(2016,7,29),
                     VoteUserName="我是左撇子",
                     ProjectID=1,
                     ActivityID=2,
                     ActivityName="左右手哪边最好用",
                     ProjectName="左手",
                     UserID=33
                },
                     new Record{
                     VoteTime=new DateTime(2016,7,29),
                     VoteUserName="c君",
                     ProjectID=1,
                     ActivityID=2,
                     ActivityName="左右手哪边最好用",
                     ProjectName="左手",
                     UserID=66
                }
            };
        }
    }
}


