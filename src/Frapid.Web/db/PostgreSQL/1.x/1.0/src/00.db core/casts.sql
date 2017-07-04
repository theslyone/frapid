DROP FUNCTION IF EXISTS text_to_bigint(text) CASCADE;
CREATE FUNCTION text_to_bigint(text) RETURNS bigint AS 'SELECT int8in(textout($1));' LANGUAGE SQL STRICT IMMUTABLE;

ALTER TYPE text OWNER TO frapid_db_user;
/*ALTER TYPE bigint OWNER TO frapid_db_user;
*/
CREATE CAST (text AS bigint) WITH FUNCTION text_to_bigint(text) AS IMPLICIT;