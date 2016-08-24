using System;

namespace DynamicIsNotMagic.Examples
{
    public interface ISubject { }
    public class UserRegisteredSubject : ISubject {/**/}
    public class UserPasswordChangedSubject : ISubject {/**/}

    public interface IEventListener
    {
        void OnEvent(ISubject subject);
    }
    public interface IEventListener<TSubject> where TSubject : class, ISubject
    {
        void OnEventRaised(TSubject subject);
    }

    #region Dynamic
    public abstract class EventListenerBase : IEventListener, IEventListener<ISubject>
    {
        public void OnEvent(ISubject subject) => OnEventRaised((dynamic)subject);
        public void OnEventRaised(ISubject subject)
        {
            throw new NotSupportedException();
        }
    }

    public class UserEventsListener : EventListenerBase,
        IEventListener<UserRegisteredSubject>, IEventListener<UserPasswordChangedSubject>
    {
        public void OnEventRaised(UserRegisteredSubject subject) {/**/}
        public void OnEventRaised(UserPasswordChangedSubject subject) {/**/}
    }

    public class UsageDynamic
    {
        public void Method()
        {
            IEventListener eventListener = new UserEventsListener();
            eventListener.OnEvent(new UserRegisteredSubject());
        }
    }
    #endregion

    #region NoDynamic
    public class UserEventsListenerNoDynamic : IEventListener,
        IEventListener<UserRegisteredSubject>, IEventListener<UserPasswordChangedSubject>
    {
        public void OnEvent(ISubject subject)
        {
            if (subject is UserRegisteredSubject)
                OnEventRaised(subject as UserRegisteredSubject);
            else if (subject is UserPasswordChangedSubject)
                OnEventRaised(subject as UserPasswordChangedSubject);
            else
                throw new NotSupportedException();
        }

        public void OnEventRaised(UserRegisteredSubject subject) {/**/}

        public void OnEventRaised(UserPasswordChangedSubject subject) {/**/}
    }

    public class UsageNoDynamic
    {
        public void Method()
        {
            IEventListener eventListener = new UserEventsListenerNoDynamic();
            eventListener.OnEvent(new UserRegisteredSubject());
        }
    }
    #endregion
}
