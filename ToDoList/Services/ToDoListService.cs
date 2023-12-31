﻿using AutoMapper;
using MediatR;
using System.Runtime.InteropServices;
using ToDoList.Api.Contracts;
using ToDoList.Api.Models;
using ToDoList.Domain.Commands;
using ToDoList.Domain.Objects;
using ToDoList.Domain.Queries;

namespace ToDoList.Api.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ToDoListService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<GetItemModel> GetItemById(Guid itemId, string userName)
        {
            var result = await _mediator.Send(new GetToDoItemsByIdQuery(itemId, userName));
            return _mapper.Map<GetItemModel>(result);
        }

        public async Task<IEnumerable<GetItemModel>> GetItems(string userName)
        {
            var result = await _mediator.Send(new GetToDoItemsListQuery(userName));
            return _mapper.Map<IEnumerable<GetItemModel>>(result);
        }

        public async Task<int> Insert(string itemTitle, string itemDescription, string userName)
        {
            return await _mediator.Send(new InsertToDoItemCommand(itemTitle, itemDescription, userName));
        }

        public async Task<int> Update(Guid id, string itemTitle, string itemDescription, bool isCompleted, DateTime completionDate, string userName)
        {
            return await _mediator.Send(new UpdateToDoItemCommand(id,itemTitle, itemDescription, isCompleted, completionDate, userName));
        }

        public async Task<int> Delete(Guid id, string userName)
        {
            return await _mediator.Send(new DeleteToDoItemCommand(id, userName));
        }

        public async Task<int> MarkAsComplete(Guid id, string userName)
        {
            return await _mediator.Send(new MarkAsCompleteCommand(id, userName));
        }

        public async Task<IEnumerable<GetItemModel>> Search(Filter filter, string userName)
        {
            
            var cleanedFilter = CleanFilter(filter);
            var result = await _mediator.Send(new SearchListQuery(cleanedFilter, userName));
            return _mapper.Map<IEnumerable<GetItemModel>>(result);
        }

        private Filter CleanFilter(Filter filter)
        {
            Dictionary<string, string> validatedFilterlist = new Dictionary<string, string>();
            foreach (var item in filter.FiltersList)
            {
                if (!string.IsNullOrEmpty(item.Value))
                    validatedFilterlist.Add(item.Key, item.Value);
            }
            var validatedFilter = new Filter();
            validatedFilter.FiltersList = validatedFilterlist;
            return validatedFilter;
        }
    }
}
