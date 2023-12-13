using ToDoList.Persistence.Entities;

namespace ToDoList.Tests.Database
{
    public static class FakeDatabase
    {
        public static List<ToDoListItem> GetFakeItems()
        {
            return new List<ToDoListItem>()
            {
                new ToDoListItem
                {
                    ItemId = new Guid("fd9daeb1-9eab-4ef5-b0cf-4d771864db14"),
                    ItemTitle = "Unit Test Item",
                    ItemDescription = "Unit Test Item Description",
                    IsCompleted = false,
                    UserId = "67717abb-93bc-4537-8dc1-5f54f33ca27e",
                    CompletionDate = DateTime.Now,
                    User = GetUnitTestUser()
                }};
            }
        public static List<User> GetFakeUsers()
        {
            return new List<User>()
            {
                GetUnitTestUser()
            };
        }

        private static User GetUnitTestUser()
        {
            return new User
            {
                Id = "67717abb-93bc-4537-8dc1-5f54f33ca27e",
                UserName = "Kareem@UnitTest",
                Email = "Kareem@UnitTest"
            };
        }
    } 
}
