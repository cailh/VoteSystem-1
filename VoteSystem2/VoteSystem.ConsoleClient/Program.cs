using System;
using VoteSystem.Logic.Models;
using VoteSystem.Logic.Services;

namespace VoteSystem.ConsoleClient
{
    class Program
    {
        static User _currentUser = null;
        static void Main(string[] args)
        {
            ShowLoginOrExit();
            while (true)
            {
                int selectLoginOrExit = GetSelectNumber();
                switch (selectLoginOrExit)
                {
                    case 1:
                        Login();
                        SelectFunction();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("你的输入有误！请重新输入：");
                        break;
                }
            }
        }
        static void ShowLoginOrExit()
        {
            Console.WriteLine("1、登陆");
            Console.WriteLine("2、退出");
            Console.WriteLine("请选择（1—2）");
        }
        static int GetSelectNumber()
        {
            int inputnumber = 0;
            while (true)
            {
                try
                {
                    inputnumber = Convert.ToInt16(Console.ReadLine());
                    return inputnumber;
                }
                catch
                {
                    Console.Write("你的输入有误，重新输入：");
                }
            }
        }
        static string InputUserName()
        {
            Console.Write("请输入用户名：");
            var userName = Console.ReadLine();
            return userName;
        }
        static string InputPassword()
        {
            Console.Write("请输入密码：");
            var password = Console.ReadLine();
            return password;
        }
        static void Login()
        {
            UserService user = new UserService();
            while (true)
            {
                Console.Clear();
                var userName = InputUserName();
                var password = InputPassword();
                try
                {
                    _currentUser = user.CheckUserIfLogin(userName, password);
                    break;
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            Console.Clear();
            Console.WriteLine("登陆成功！");
        }
        static void ShowFunctionScreen()
        {
            Console.WriteLine("1 参与投票");
            Console.WriteLine("2 查看投票项目列表");
            Console.WriteLine("3 查看所有投票记录");
            Console.WriteLine("4 查看指定项目投票记录");
            Console.WriteLine("5 注销");
            Console.WriteLine("6 登陆");
            Console.WriteLine("7 退出");
            Console.WriteLine("输入数字（1—7）：");
        }
        static void SelectFunction()
        {
            VoteService service = new VoteService();
            while (true)
            {
                ShowFunctionScreen();
                int selectFunctionNumber = GetSelectNumber();
                switch (selectFunctionNumber)
                {
                    case 1:
                        Vote();
                        break;
                    case 2:
                        GetAppointActivityProjectList();
                        break;
                    case 3:
                        GetAllProjectVoteHistory();
                        break;
                    case 4:
                        GetAppointProjectRecord();
                        break;
                    case 5:_currentUser = null;
                        break;
                    case 6:
                        Login();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("你的输入有误！请重新输入：");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void Vote()
        {
            VoteService vote = new VoteService();
            int getActivityId;
            int getProjectId;
            try
            {
                vote.CheckUserIfExist(_currentUser);
                ShowActivityAndProject();
                Console.WriteLine("请输入所选活动编号：");
                getActivityId = GetSelectNumber();
                Console.WriteLine("请输入所选项目编号：");
                getProjectId = GetSelectNumber();
                Console.ReadKey();
                Console.Clear();
                    try
                    {
                        vote.CheckVoteIfSuccess(_currentUser, getActivityId, getProjectId);
                        var project = vote.GetTheProject(getActivityId, getProjectId);
                        project.VoteNumber++;
                        Console.WriteLine("在“{0}”活动中\n “{1}” 为“{2}”投了票，投票时间：{3}  ，该活动现有{4}张票", project.ActivityName, _currentUser.UserName, project.ProjectName, DateTime.Now, project.VoteNumber);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //static int GetVoteActivityId()
        //{
        //    VoteService vote = new VoteService();
        //    int getActivityId;
        //    while (true)
        //    {
        //        getActivityId = GetSelectNumber();
        //        try
        //        {
        //           // vote.CheckActivity(_currentUser.UserID, getActivityId,);
        //            Console.Clear();
        //            ShowProjects(getActivityId);
        //            return getActivityId;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            Console.WriteLine("重新输入：");
        //        }
        //    }
        //}
        static int GetProjectId(int activityId)
        {
            VoteService vote = new VoteService();
            int getProjectId;
            while (true)
            {
                getProjectId = GetSelectNumber();
                try
                {
                    vote.CheckProjectIfExist(activityId, getProjectId);
                    Console.Clear();
                    return getProjectId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("重新输入：");
                }
            }
    }
        static void ShowActivityAndProject()
        {
            VoteService vote = new VoteService();
            var activities = vote.GetVoteActivities();
            Console.Clear();
            foreach (var activity in activities)
            {
                Console.WriteLine("活动名： {0}", activity.ActivityName);
                Console.WriteLine("活动编号：{0}", activity.ActivityID);
                Console.WriteLine("活动简介：{0}", activity.ActivityIntroduction);
                Console.WriteLine("开始时间：{0}", activity.StartTime);
                Console.WriteLine("结束时间：{0}", activity.EndTime);
                Console.WriteLine("\n");
                var projects = vote.GetVoteProject(activity.ActivityID);
                foreach (var project in projects)
                {
                    Console.WriteLine("项目名称:  {0}", project.ProjectName);
                    Console.WriteLine("项目编号:  {0}", project.ProjectID);
                    Console.WriteLine("项目简介:  {0}", project.ProjectIntroduction);
                    Console.WriteLine("投票数:  {0}", project.VoteNumber);
                    Console.WriteLine("活动名称:  {0}", project.ActivityName);
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n\n");
            }
        }
        static void ShowActivities()
        {
            VoteService vote = new VoteService();
            var activities = vote.GetVoteActivities();
            Console.Clear();
            foreach (var activity in activities)
            {
                Console.WriteLine("活动名： {0}", activity.ActivityName);
                Console.WriteLine("活动编号：{0}", activity.ActivityID);
                Console.WriteLine("活动简介：{0}", activity.ActivityIntroduction);
                Console.WriteLine("开始时间：{0}", activity.StartTime);
                Console.WriteLine("结束时间：{0}", activity.EndTime);
                Console.WriteLine("\n");
            }
        }
        static void ShowProjects(int activityId)
        {
            VoteService service = new VoteService();
            var projects = service.GetVoteProject(activityId);
            foreach (var project in projects)
            {
                Console.WriteLine("项目名称:  {0}", project.ProjectName);
                Console.WriteLine("项目编号:  {0}", project.ProjectID);
                Console.WriteLine("项目简介:  {0}", project.ProjectIntroduction);
                Console.WriteLine("投票数:  {0}", project.VoteNumber);
                Console.WriteLine("活动名称:  {0}", project.ActivityName);
            }
        }
        
        static void GetAppointActivityProjectList()
        {
            VoteService service = new VoteService();
            int getActivityId;
            ShowActivities();
            Console.WriteLine("请输入所选活动编号：");
            getActivityId = GetActivityId();
            Console.ReadKey();
            Console.Clear();
            ShowProjects(getActivityId);
        }
        static int GetActivityId()
        {
            VoteService service = new VoteService();
            int getActivityId;
            while (true)
            {
                getActivityId = GetSelectNumber();
                try
                {
                    service.CheckActivityIfExist(getActivityId);
                    return getActivityId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("重新输入：");
                }
            }
        }
        static void GetAllProjectVoteHistory()
        {
            VoteService service = new VoteService();
            var records = service.GetAllVoteProjectRecords();
            foreach (var record in records)
            {
                Console.WriteLine("项目名称:  {0}", record.ProjectName);
                Console.WriteLine("投票人:  {0}", record.VoteUserName);
                Console.WriteLine("活动名称:  {0}", record.ActivityName);
                Console.WriteLine("投票时间:  {0}", record.VoteTime);
            }
        }
        public static void GetAppointProjectRecord()
        {
            VoteService service = new VoteService();
            int getActivityId;
            int getProjectId;
            ShowActivities();
            Console.WriteLine("请输入所选活动编号：");
            getActivityId = GetActivityId();
            Console.ReadKey();
            Console.Clear();
            ShowProjects(getActivityId);
            Console.WriteLine("请输入所选项目编号：");
            getProjectId = GetProjectId(getActivityId);
            var records = service.GetTheProjectVoteRecords(getActivityId, getProjectId);
            foreach (var record in records)
            {
                Console.WriteLine("项目名称:  {0}", record.ProjectName);
                Console.WriteLine("投票人:  {0}", record.VoteUserName);
                Console.WriteLine("活动名称:  {0}", record.ActivityName);
                Console.WriteLine("投票时间:  {0}", record.VoteTime);
            }
        }
    }
}
