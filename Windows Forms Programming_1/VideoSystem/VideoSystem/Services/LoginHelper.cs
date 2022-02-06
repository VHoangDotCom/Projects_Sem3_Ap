using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoSystem.Models;
using Windows.Security.Credentials;

namespace VideoSystem.Services
{
    public static class LoginHelper
    {
        public static async Task<bool> MicrosoftPassportAvailableCheckAsync()
        {
            bool keyCredentialAvailable = await KeyCredentialManager.IsSupportedAsync();
            if (keyCredentialAvailable == false)
            {
                // Key credential is not enabled yet as user 
                // needs to connect to a Microsoft Account and select a PIN in the connecting flow.
                Debug.WriteLine("Microsoft Passport is not setup!\nPlease go to Windows Settings and set up a PIN to use it.");
                return false;
            }
            return true;
        }

        public static async Task<bool> CreatePassportKeyAsync(string accountId, string password)
        {
            KeyCredentialRetrievalResult keyCreationResult = await KeyCredentialManager.RequestCreateAsync(accountId, KeyCredentialCreationOption.ReplaceExisting);
            KeyCredentialRetrievalResult keyCreationResult1 = await KeyCredentialManager.RequestCreateAsync(password, KeyCredentialCreationOption.ReplaceExisting);
            switch (keyCreationResult.Status )
            {
                case KeyCredentialStatus.Success:
                    Debug.WriteLine("Successfully made key");

                    // In the real world authentication would take place on a server.
                    // So every time a user migrates or creates a new Microsoft Passport account Passport details should be pushed to the server.
                    // The details that would be pushed to the server include:
                    // The public key, keyAttesation if available, 
                    // certificate chain for attestation endorsement key if available,  
                    // status code of key attestation result: keyAttestationIncluded or 
                    // keyAttestationCanBeRetrievedLater and keyAttestationRetryType
                    // As this sample has no concept of a server it will be skipped for now
                    // for information on how to do this refer to the second Passport sample

                    //For this sample just return true
                    return true;
                case KeyCredentialStatus.UserCanceled:
                    Debug.WriteLine("User cancelled sign-in process.");
                    break;
                case KeyCredentialStatus.NotFound:
                    // User needs to setup Microsoft Passport
                    Debug.WriteLine("Microsoft Passport is not setup!\nPlease go to Windows Settings and set up a PIN to use it.");
                    break;
                default:
                    break;
            }
            return false;
        }

        public static async void RemovePassportAccountAsync(AccountGallery account)
        {
            // Open the account with Passport
            KeyCredentialRetrievalResult keyOpenResult = await KeyCredentialManager.OpenAsync(account.email);
            KeyCredentialRetrievalResult keyOpenResult1 = await KeyCredentialManager.OpenAsync(account.password);

            if (keyOpenResult.Status == KeyCredentialStatus.Success)
            {
                // In the real world you would send key information to server to unregister
                //for example, RemovePassportAccountOnServer(account);
            }else if(keyOpenResult1.Status == KeyCredentialStatus.Success)

            // Then delete the account from the machines list of Passport Accounts
            await KeyCredentialManager.DeleteAsync(account.email);
            await KeyCredentialManager.DeleteAsync(account.password);
        }

        public static async Task<bool> GetPassportAuthenticationMessageAsync(AccountGallery account)
        {
            KeyCredentialRetrievalResult openKeyResult = await KeyCredentialManager.OpenAsync(account.email);
            KeyCredentialRetrievalResult openKeyResult1 = await KeyCredentialManager.OpenAsync(account.password);
            // Calling OpenAsync will allow the user access to what is available in the app and will not require user credentials again.
            // If you wanted to force the user to sign in again you can use the following:
            // var consentResult = await Windows.Security.Credentials.UI.UserConsentVerifier.RequestVerificationAsync(account.Username);
            // This will ask for the either the password of the currently signed in Microsoft Account or the PIN used for Microsoft Passport.

            if (openKeyResult.Status == KeyCredentialStatus.Success)
            {
                // If OpenAsync has succeeded, the next thing to think about is whether the client application requires access to backend services.
                // If it does here you would Request a challenge from the Server. The client would sign this challenge and the server
                // would check the signed challenge. If it is correct it would allow the user access to the backend.
                // You would likely make a new method called RequestSignAsync to handle all this
                // for example, RequestSignAsync(openKeyResult);
                // Refer to the second Microsoft Passport sample for information on how to do this.

                // For this sample there is not concept of a server implemented so just return true.
                return true;
            }else if(openKeyResult1.Status == KeyCredentialStatus.Success)
            {
                return true;
            }
            else if (openKeyResult.Status == KeyCredentialStatus.NotFound && openKeyResult1.Status == KeyCredentialStatus.NotFound)
            {
                // If the _account is not found at this stage. It could be one of two errors. 
                // 1. Microsoft Passport has been disabled
                // 2. Microsoft Passport has been disabled and re-enabled cause the Microsoft Passport Key to change.
                // Calling CreatePassportKey and passing through the account will attempt to replace the existing Microsoft Passport Key for that account.
                // If the error really is that Microsoft Passport is disabled then the CreatePassportKey method will output that error.
                if (await CreatePassportKeyAsync(account.email,account.password) )
                {
                    // If the Passport Key was again successfully created, Microsoft Passport has just been reset.
                    // Now that the Passport Key has been reset for the _account retry sign in.
                    return await GetPassportAuthenticationMessageAsync(account);
                }
            }
            // Can't use Passport right now, try again later
            return false;
        }
    }
}
