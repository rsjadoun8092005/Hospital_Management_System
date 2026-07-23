global using System;
global using System.Collections.Generic;
global using System.Text.Json;
global using System.Threading.Tasks;

global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Models;

global using HMS.Application.Commands;
global using HMS.Application.Exceptions;
global using HMS.Application.Extensions;
global using HMS.Application.Queries;
global using HMS.Core.Common;
global using HMS.Infrastructure.Data;
global using HMS.Infrastructure.Extensions;

global using MediatR;
