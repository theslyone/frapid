INSERT INTO account.roles
SELECT 1000,   'Guest',                 false UNION ALL
SELECT 2000,   'Freebe User',          false UNION ALL
SELECT 3000,   'Partner',               false UNION ALL
SELECT 4000,   'Content Editor',        false UNION ALL
SELECT 5000,   'Backoffice User',       false UNION ALL
SELECT 9999,   'Admin',                 true;


INSERT INTO account.configuration_profiles(profile_name, is_active, allow_registration, registration_role_id, registration_office_id)
SELECT 'Default', true, true, 2000, 1;

INSERT INTO account.users(user_id, email, password, office_id, role_id, name, phone)
SELECT 99999999, 'admin@freebe.com.ng', '$2a$10$Rb.YOG2xs0ncVlhuDEtuWend/SXsJKpr3TZjhZH9MKJp7xf1RKu3K', 1, 9999, 'Freebe Administrator', '';

INSERT INTO account.logins(login_id, user_id, office_id, ip_address, is_active, culture)
SELECT 99999999, 99999999, 1, '::1', true, 'en-US';