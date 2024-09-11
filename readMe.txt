                                                        READ ME
Instructions to run
- dotnet build
- dotnet test

        Features

- Reused code by allowing for dynamic values in the steps such as the status code which is used at the end of each API call. 

- Error messages for debugging.

- Variables throughout to improve readability and reusability of code.

- Explicit and easy to follow comments throughout.

- Added additional checks for scenarios to check can handle not just the happy case.

- Explicit test case names and variable names



        Potential improvements 

I would add some basic schema checks for the test returning the 5 results to ensure to ensure variable types and 
  structure of the response is correct

I would add a test for call duration on each on per call basis 

Is definitely room to improve on the code quality and good practices in hindsight, but think a lot of this is due to not having 
experience with specflow, I am familiar with cucumber and all of the concepts but it was my first time ever using 
specflow and its structure.

I have previously exclusively used a mix of Postman, Burpsuite and Proxyman. So was a really interesting process of trial 
and error to get it working and I have really enjoyed the learning curve and seeing the pros and cons of each. 
Some of the syntax rules and the structure of the function names in the Steps linking to the Feature was the hardest bit 
to grasp coming from a background of doing a lot of typescript/javascript.

Apologies for the lack of regular commits and commit messages. Have been away on a long weekend and had quite a lot 
commitments so has been a bit hectic getting it done in time.