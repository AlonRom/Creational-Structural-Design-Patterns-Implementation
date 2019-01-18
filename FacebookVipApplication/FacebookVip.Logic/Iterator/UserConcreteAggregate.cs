using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Models;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Iterator
{
    // the concrete user friends aggregate
    public class UserConcreteAggregate : IAggregate, IAsyncInitialization
    {
        private readonly User r_LoggedInUser;
        public Task Initialization { get; }
        private List<FriendModel> m_UserFriends;

        public UserConcreteAggregate(User i_LoggedInUser)
        {
            r_LoggedInUser = i_LoggedInUser;
            Initialization = initializeAsync();
        }

        private async Task initializeAsync()
        {
            IFriendService friendService = new FriendService();
            m_UserFriends = await friendService.GetUserFriendsAsync(r_LoggedInUser);
        }

        public IIterator CreateIterator()
        {
            return new UserFriendsIterator(this);
        }

        private class UserFriendsIterator : IIterator
        {
            private readonly UserConcreteAggregate r_Aggregate;
            private int m_CurrentIdx = -1;
            private readonly int r_Count;

            public UserFriendsIterator(UserConcreteAggregate i_ConcreteAggregate)
            {
                r_Aggregate = i_ConcreteAggregate;
                r_Count = r_Aggregate.m_UserFriends.Count;
            }

            public bool MoveNext()
            {
                if (r_Count != r_Aggregate.m_UserFriends.Count)
                {
                    throw new Exception("Collection can not be changed during iteration!");
                }
                if (m_CurrentIdx >= r_Count)
                {
                    throw new Exception("Already reached the end of the collection");
                }

                return ++m_CurrentIdx < r_Aggregate.m_UserFriends.Count;
            }

            public object Current => r_Aggregate.m_UserFriends[m_CurrentIdx];

            public void Reset()
            {
                m_CurrentIdx = -1;
            }
        }
    }
}
