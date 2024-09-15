# SimplyInfraEngineer


## Schemas
There is no JSON schemas provided; that a quick Google search could find, that we can check our responses against so we are inferring types and possible values from the examples given on the (https://opsgenie.status.atlassian.com/api/v2) page.

Where there is no concreate type given we will fall back to a basic `string` to cover all possible inputs.

For the `incidents` JSON object it's unclear even more as to what should and will be provided by the JSON response, the example on the page above only shows a small subset compared to a select few examples taken from the live data.

As we are only interested in `Incident name`, `Incident creation time` and `Incident status` we will check to make sure those are at least supplied; and error handle if not, but will otherwise discard anything else provided by the JSON response.