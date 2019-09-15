using SHBL.SPT.BASE;
using SHBL.SPT.BASE.Providers;
using SHBL.SPT.DAL.Context;
using SHBL.SPT.DALFactory;
using System;

namespace SHBL.SPT.Business
{
    public class SptUnitOfWork : IDisposable //: SafeSingletonProvider<SptUnitOfWork>
    {
        private readonly object _PadLock = new object();

        private SptContext _Context;
        private SptContext context
        {
            get
            {
                if (_Context == null || _Context.Database.Connection == null)
                {
                    lock (_PadLock)
                    {
                        if (_Context == null || _Context.Database.Connection == null)
                        {
                            _Context = new SptContext();
                        }
                    }
                }

                return _Context;
            }
        }

        //SptContext context = new SptContext();
        private bool disposed = false;

        private IUserRepository _userRepository;
        private IPersonRepository _personRepository;
        private ICFTypeRepository _cFTypeRepository;
        private ICFTypeSpeakerRepository _cFTypeSpeakerRepository;
        private ISpeakerRepository _speakerRepository;
        private IActivityRepository _activityRepository;
        private IUserActivityRepository _userActivityRepository;
        private IUserActivityDetailRepository _userActivityDetailRepository;
        private IWordRepository _wordRepository;
        private IWordSpeakerRepository _wordSpeakerRepository;
        private IEventLogRepository _eventLogRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = RepositoryFactory.Instance.Resolve<IUserRepository>();
                    _userRepository.BaseContext = context;
                }
                return _userRepository;
            }
        }

        public IPersonRepository PersonRepository
        {
            get
            {
                if (_personRepository == null)
                {
                    _personRepository = RepositoryFactory.Instance.Resolve<IPersonRepository>();
                    _personRepository.BaseContext = context;
                }
                return _personRepository;
            }
        }

        public ISpeakerRepository SpeakerRepository
        {
            get
            {
                if (_speakerRepository == null)
                {
                    _speakerRepository = RepositoryFactory.Instance.Resolve<ISpeakerRepository>();
                    _speakerRepository.BaseContext = context;
                }
                return _speakerRepository;
            }
        }

        public ICFTypeRepository CFTypeRepository
        {
            get
            {
                if (_cFTypeRepository == null)
                {
                    _cFTypeRepository = RepositoryFactory.Instance.Resolve<ICFTypeRepository>();
                    _cFTypeRepository.BaseContext = context;
                }
                return _cFTypeRepository;
            }
        }

        public ICFTypeSpeakerRepository CFTypeSpeakerRepository
        {
            get
            {
                if (_cFTypeSpeakerRepository == null)
                {
                    _cFTypeSpeakerRepository = RepositoryFactory.Instance.Resolve<ICFTypeSpeakerRepository>();
                    _cFTypeSpeakerRepository.BaseContext = context;
                }
                return _cFTypeSpeakerRepository;
            }
        }

        public IActivityRepository ActivityRepository
        {
            get
            {
                if (_activityRepository == null)
                {
                    _activityRepository = RepositoryFactory.Instance.Resolve<IActivityRepository>();
                    _activityRepository.BaseContext = context;
                }
                return _activityRepository;
            }
        }

        public IUserActivityRepository UserActivityRepository
        {
            get
            {
                if (_userActivityRepository == null)
                {
                    _userActivityRepository = RepositoryFactory.Instance.Resolve<IUserActivityRepository>();
                    _userActivityRepository.BaseContext = context;
                }
                return _userActivityRepository;
            }
        }

        public IUserActivityDetailRepository UserActivityDetailRepository
        {
            get
            {
                if (_userActivityDetailRepository == null)
                {
                    _userActivityDetailRepository = RepositoryFactory.Instance.Resolve<IUserActivityDetailRepository>();
                    _userActivityDetailRepository.BaseContext = context;
                }
                return _userActivityDetailRepository;
            }
        }

        public IWordRepository WordRepository
        {
            get
            {
                if (_wordRepository == null)
                {
                    _wordRepository = RepositoryFactory.Instance.Resolve<IWordRepository>();
                    _wordRepository.BaseContext = context;
                }
                return _wordRepository;
            }
        }

        public IWordSpeakerRepository WordSpeakerRepository
        {
            get
            {
                if (_wordSpeakerRepository == null)
                {
                    _wordSpeakerRepository = RepositoryFactory.Instance.Resolve<IWordSpeakerRepository>();
                    _wordSpeakerRepository.BaseContext = context;
                }
                return _wordSpeakerRepository;
            }
        }

        public IEventLogRepository EventLogRepository
        {
            get
            {
                if (_eventLogRepository == null)
                {
                    _eventLogRepository = RepositoryFactory.Instance.Resolve<IEventLogRepository>();
                    _eventLogRepository.BaseContext = context;
                }
                return _eventLogRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
