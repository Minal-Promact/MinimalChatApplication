using AutoMapper;
using MinimalChatApplication.Data;
using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.DTO.ResponseDTO;
using MinimalChatApplication.Helper;
using MinimalChatApplication.Model;
using MinimalChatApplication.Repository.Interface;

namespace MinimalChatApplication.Repository.Implementation
{
    public class RequestLoggingMiddleware : IRequestLoggingMiddleware
    {
        private readonly EFDataContext dbContext;
        private readonly IMapper _mapper;

        public RequestLoggingMiddleware(EFDataContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestLogging> PostRequestLoggingMiddleware(LogResponse logResponse)
        {
            var requestLoggingMiddleware = _mapper.Map<LogResponse, RequestLogging>(logResponse);
           
            await dbContext.RequestLoggingMiddlewares.AddAsync(requestLoggingMiddleware);
            await dbContext.SaveChangesAsync();

            return requestLoggingMiddleware;
        }

        public async Task<List<RequestLogging>> GetRequestLoggingMiddleware(FromQueryRequestLogging  fromQueryRequestLogging)
        {
            return dbContext.RequestLoggingMiddlewares.Where(log => log.timeOfCall >= fromQueryRequestLogging.StartDateTime && log.timeOfCall <= fromQueryRequestLogging.EndDateTime).OrderBy(log => log.timeOfCall).ToList();
        }
    }
}
