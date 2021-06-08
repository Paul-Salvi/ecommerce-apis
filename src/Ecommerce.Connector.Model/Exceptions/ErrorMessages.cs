using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Connector.Model
{
    public static partial class ErrorMessages
    {

        public static string RequestNotFound()
        {
            return FaultMessages.RequestNotFound;
        }

        public static string ValidationFailure()
        {
            return FaultMessages.ValidationFailure;
        }

        public static string MandatoryFieldMissing(string fieldName)
        {
            return string.Format(FaultMessages.MandatoryFieldMissing, fieldName);
        }

        public static string ValueCannotBeNullOrEmptyForMandatoryField(string field)
        {
            return string.Format(FaultMessages.ValueCannotBeNullOrEmptyForMandatoryField, field);
        }

        public static string InvalidValueForInputType(string path, string property, string type)
        {
            return string.Format(FaultMessages.InvalidValueForInputType, path, property, type);
        }

        public static string InvalidDateTimeFormat(string path, string property)
        {
            return string.Format(FaultMessages.InvalidDateTimeFormat, path, property);
        }

        public static string MissingRequestHeaders(List<string> headerNames)
        {
            return string.Format(FaultMessages.MissingRequestHeaders, string.Join(", ", headerNames));
        }

        public static string InvalidRequestHeaders(List<string> headerNames)
        {
            return string.Format(FaultMessages.InvalidRequestHeaders, string.Join(", ", headerNames));
        }

        public static string ServiceCommunication(string serviceName)
        {
            return string.Format(FaultMessages.ServiceCommunication, serviceName);
        }

        public static string UnexpectedSystemException()
        {
            return FaultMessages.UnexpectedSystemException;
        }
        public static string CouldNotResolveType(string type, string error)
        {
            return string.Format(FaultMessages.CouldNotResolveType, type, error);
        }
        public static string ParameterStoreCommunicationError()
        {
            return FaultMessages.ParameterStoreCommunicationError;
        }

        public static string MissingKeysInParameterStore(List<string> keys)
        {
            return string.Format(FaultMessages.MissingKeysInParameterStore, string.Join(", ", keys));
        }
    }
}