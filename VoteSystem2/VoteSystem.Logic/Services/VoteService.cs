using System;
using System.Collections.Generic;
using System.Linq;
using VoteSystem.Logic.Data;
using VoteSystem.Logic.Models;

namespace VoteSystem.Logic.Services
{
    public class VoteService
    {
        public List<Activity> GetVoteActivities()
        {
            return DataCollection.VoteActivities.ToList();
        }
        public List<Project> GetVoteProject(int activityId)
        {
            return DataCollection.VoteProject.Where(p => p.ActivityID == activityId).ToList();
        }
        public void CheckUserIfExist(User user)
        {
            if (user == null)
                throw new Exception("你还没有登陆!请登陆后再投票！");
        }
        public void CheckActivityIfExist(int activityId)
        {
            var activity = DataCollection.VoteActivities.SingleOrDefault(a => a.ActivityID == activityId);
            if (activity == null)
                throw new Exception("不存在该活动!");//请重新输入：
        }
        public void CheckIfVote(int activityId,int userId)
        {
            var person = DataCollection.VoteRecords.SingleOrDefault(p => p.ActivityID == activityId && p.UserID==userId);
            if (person != null)
                throw new Exception("你已经对该活动投过票了!");
        }
        public void CheckTimeInActivity(int activityId)
        {
            var time = DataCollection.VoteActivities.SingleOrDefault(t => t.ActivityID == activityId);
            DateTime startTime = time.StartTime;
            DateTime endTime = time.EndTime;
            DateTime nowTime = DateTime.Now;
            if (DateTime.Compare(startTime, nowTime) > 0 && DateTime.Compare(endTime, nowTime) < 0)
                throw new Exception("该活动不在投票时间内!");
        }
        public void CheckProjectIfExist(int projectId,int activityId)
        {
            var project = DataCollection.VoteProject.SingleOrDefault(p => p.ActivityID == activityId && p.ProjectID == projectId);
            if (project == null)
                throw new Exception("该活动不存在该项目!");
        }
        public void CheckVoteIfSuccess(User user, int activityId,int projectId)
        {
            try
            {
                CheckActivityIfExist(activityId); //1.判断活动是否存在
                CheckTimeInActivity(activityId); //2.判断活动是否在投票时间内
                CheckIfVote(activityId, user.UserID);//3.判断用户是否投过票
                CheckProjectIfExist(activityId, projectId);//4.判断项目是否存在
                AddVoteResultToRecord(activityId, projectId, user);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("投票失败！");
            }
        }
        public Project GetTheProject(int activityId, int projectId)
        {
            return DataCollection.VoteProject.SingleOrDefault(p => p.ActivityID == activityId && p.ProjectID == projectId); 
        }
        public void AddVoteResultToRecord(int activityId, int projectId,User user)
        {
            var project = GetTheProject(activityId, projectId);
            Record record = new Record()
            {
                VoteTime = DateTime.Now,
                VoteUserName = user.UserName,
                ActivityID = project.ActivityID,
                ProjectID = project.ProjectID,
                ActivityName = project.ActivityName,
                ProjectName = project.ProjectName,
                UserID = user.UserID
            };
            Logic.Data.DataCollection.VoteRecords.Add(record);
        }
        public List<Record> GetAllVoteProjectRecords()
        {
            return DataCollection.VoteRecords.ToList();
        }
        public List<Record> GetTheProjectVoteRecords(int activityId, int projectId)
        {
            return DataCollection.VoteRecords.Where(r=>r.ActivityID==activityId&&r.ProjectID==projectId).ToList();
        }
    }
}
