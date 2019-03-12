using System.Collections.Generic;
using System.Linq;


namespace GameBlogApplication.Services
{
    public class GameBlogService
    {
        /*
         * Notes:
         * A lot of methods are commented out because some models do not exist yet
         * For the discussion data, I named OwnerProfileImage O'nw'erProfileImage. It's misspelled
         * 
         * Profile
         * -Get Profile by ID
         * -Create Profile
         * -Update Profile
         * -Delete Profile
         * 
         * Discussion
         * -Get Discussion by ID
         * -Create Discussion
         * -Update Discussion
         * -DeleteDiscussion
         * 
         * Misc.
         * -Connect Discussions to Users: Create UserDiscussion
         * -Delete UserDiscussions if User is deleted
         * -Delete UserDiscussion if Discussion is deleted
         */

            //Users
        public User GetUserByID(int id)
        {
            User user = null;
            using (var context = new ITPEntities())
            {
                user = context.Users.FirstOrDefault(u => u.AccountID == id);
            }

            if(user == null)
            {
                return null;
            }

            User result = new User()
            {
                AccountID = user.AccountID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Age = user.Age,
                Birthday = user.Birthday,
                ProfileImage = user.ProfileImage,
                Bio = user.Bio
            };

            return result;
        }

        public void CreateUser(User model)
        {
            using (var context = new ITPEntities())
            {
                User newUser = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    Age = model.Age,
                    Birthday = model.Birthday,
                    ProfileImage = model.ProfileImage,
                    Bio = model.Bio
                };


                context.Users.Add(newUser);
                context.SaveChanges();

                model.AccountID = newUser.AccountID;
            }
        }

        public void UpdateUser(User model)
        {
            using (var context = new ITPEntities())
            {
                User userToUpdate = context.Users.FirstOrDefault(u => u.AccountID == model.AccountID);

                userToUpdate.FirstName = model.FirstName;
                userToUpdate.LastName = model.LastName;
                userToUpdate.Username = model.Username;
                userToUpdate.Email = model.Email;
                userToUpdate.Password = model.Password;
                userToUpdate.Age = model.Age;
                userToUpdate.Birthday = model.Birthday;
                userToUpdate.ProfileImage = model.ProfileImage;
                userToUpdate.Bio = model.Bio;

                context.SaveChanges();
            }
        }

        public void DeleteUserById(int id)
        {
            using (var context = new ITPEntities())
            {
                //The user to delete
                User userToDelete = context.Users.FirstOrDefault(u => u.AccountID == id);

                List<Discussion> discussionsToDelete = GetDiscussionsByUserID(userToDelete.AccountID);
                List<UserDiscussion> matchingUserIds = GetUserDiscussionsByUserID(userToDelete.AccountID);

                //Loop through the discussionsToDelete and remove discussions from database
                foreach (Discussion d in discussionsToDelete)
                {
                    DeleteDiscussionByID(d.DiscussionID);
                }
                context.SaveChanges();

                //Loop through matchingUserIds and remove userDiscussions from database
                foreach(UserDiscussion ud in matchingUserIds)
                {
                    DeleteUserDiscussionByID(ud.UserDiscussionID);
                }
                context.SaveChanges();

                //Remove user from database
                context.Users.Remove(userToDelete);
                context.SaveChanges();
            }
        }

        //UserDiscussions

        public UserDiscussion GetUserDiscussionByID(int id)
        {
            UserDiscussion ud = null;

            using (var context = new ITPEntities())
            {
                ud = context.UserDiscussions.FirstOrDefault(x => x.UserDiscussionID == id);
            }

            if (ud == null)
            {
                return null;
            }

            UserDiscussion result = new UserDiscussion()
            {

                UserDiscussionID = ud.UserDiscussionID,
                AccountId = ud.AccountId,
                DiscussionId = ud.DiscussionId
            };

            return result;

        }

        public List<UserDiscussion> GetUserDiscussionsByUserID(int userID)
        {
            List<UserDiscussion> userDiscussionWithUser = new List<UserDiscussion>();
            using (var context = new ITPEntities())
            {
                List<UserDiscussion> userDiscussions = context.UserDiscussions.ToList();

                //UserDiscussions that have the same user ID
                userDiscussionWithUser = userDiscussions.Where(ud => ud.AccountId == userID).Select(ud => ud).ToList();
            }

            return userDiscussionWithUser;
        }

        public void CreateUserDiscussion(UserDiscussion model, int userID, int discussionID)
        {
            using (var context = new ITPEntities())
            {
                UserDiscussion newUD = new UserDiscussion
                {
                    AccountId = userID,
                    DiscussionId = discussionID
                };

                context.UserDiscussions.Add(newUD);
                context.SaveChanges();
                
                model.UserDiscussionID = newUD.UserDiscussionID;
            }
        }

        public void DeleteUserDiscussionByID(int id)
        {
            using (var context = new ITPEntities())
            {
                UserDiscussion userDiscussion = context.UserDiscussions.FirstOrDefault(ud => ud.UserDiscussionID == id);
                Discussion discussion = context.Discussions.FirstOrDefault(d => d.DiscussionID == userDiscussion.DiscussionId);

                //Delete corresponding Discussion 
                context.Discussions.Remove(discussion);
                context.SaveChanges();
                context.UserDiscussions.Remove(userDiscussion);
                context.SaveChanges();
            }
        }

        public void DeleteUserDiscussionByUserID(int userID)
        {
            using (var context = new ITPEntities())
            {
                UserDiscussion userDiscussion = context.UserDiscussions.FirstOrDefault(ud => ud.UserDiscussionID == userID);
                Discussion discussion = context.Discussions.FirstOrDefault(d => d.DiscussionID == userDiscussion.DiscussionId);

                //Delete corresponding Discussion
                context.Discussions.Remove(discussion);
                context.SaveChanges();
                context.UserDiscussions.Remove(userDiscussion);
                context.SaveChanges();
            }
        }

        //Discussions
        public Discussion GetDiscussionByID(int id)
        {
            Discussion discussion = null;

            using (var context = new ITPEntities())
            {
                discussion = context.Discussions.FirstOrDefault(d => d.DiscussionID == id);
            }

            if (discussion == null) {
                return null;
            }

            Discussion result = new Discussion()
            {

                DiscussionID = discussion.DiscussionID,
                Title = discussion.Title,
                ContentText = discussion.ContentText,
                OwnerUsername = discussion.OwnerUsername,
                OnwerProfileImage = discussion.OnwerProfileImage, //I spelled owner wrong here
                Status = discussion.Status,
                DatePosted = discussion.DatePosted
            };

            return result;
        }

        public List<Discussion> GetDiscussionsByUserID(int userID)
        {
            List<Discussion> theUsersDiscussions = new List<Discussion>();
            using (var context = new ITPEntities())
            {
                List<UserDiscussion> userDiscussions = GetUserDiscussionsByUserID(userID);
                List<Discussion> discussions = context.Discussions.ToList();

                foreach (UserDiscussion ud in userDiscussions)
                {
                    //Get discussion that has the same discussionID as the current userDiscussion
                    Discussion discussion = context.Discussions.FirstOrDefault(d => d.DiscussionID == ud.DiscussionId);
                    //Add discussion to discussionsToDelete if it's not already in the list
                    if (!theUsersDiscussions.Contains(discussion))
                    {
                        theUsersDiscussions.Add(discussion);
                    }
                }
            }

            return theUsersDiscussions;
        }

        public void CreateDiscussion(Discussion model)
        {
            //Create a UserDiscussion when creating a Discussion
            using (var context = new ITPEntities())
            {
                Discussion discussion = new Discussion()
                {
                    Title = model.Title,
                    ContentText = model.ContentText,
                    OwnerUsername = model.OwnerUsername,
                    OnwerProfileImage = model.OnwerProfileImage, //I spelled owner wrong here
                    Status = model.Status,
                    DatePosted = model.DatePosted
                };

                context.Discussions.Add(discussion);
                context.SaveChanges();
                model.DiscussionID = discussion.DiscussionID;
            }
        }

        public void UpdateDiscussion(Discussion model) 
        {
            using (var context = new ITPEntities())
            {
                Discussion discussion = context.Discussions.FirstOrDefault(d => d.DiscussionID == model.DiscussionID);

                discussion.Title = model.Title;
                discussion.ContentText = model.ContentText;
                discussion.OwnerUsername = model.OwnerUsername;
                discussion.OnwerProfileImage = model.OnwerProfileImage; //I spelled owner wrong here
                discussion.Status = model.Status;
                discussion.DatePosted = model.DatePosted;

                context.SaveChanges();
            }
        }

        public void DeleteDiscussionByID(int id)
        {
            //If discussion is deleted, delete the corresponding UserDiscussion as well
            using (var context = new ITPEntities())
            {
                Discussion discussion = context.Discussions.FirstOrDefault(d => d.DiscussionID == id);
                context.Discussions.Remove(discussion);
                context.SaveChanges();
            }
        }
    }
}