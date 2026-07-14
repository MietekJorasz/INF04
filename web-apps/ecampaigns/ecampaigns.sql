-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 24 Lis 2025, 21:49
-- Wersja serwera: 10.4.24-MariaDB
-- Wersja PHP: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `ecampaigns`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `campaigns`
--

CREATE TABLE `campaigns` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `title` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` text COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `email_template_id` int(11) DEFAULT NULL,
  `status` enum('draft','scheduled','sent') COLLATE utf8mb4_unicode_ci DEFAULT 'draft',
  `created_at` datetime DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Zrzut danych tabeli `campaigns`
--

INSERT INTO `campaigns` (`id`, `user_id`, `title`, `description`, `email_template_id`, `status`, `created_at`, `updated_at`) VALUES
(1, 2, 'Dodo', 'dodo', 1, 'sent', '2025-11-11 18:34:26', '2025-11-24 20:21:38'),
(2, 2, 'Promocja Black Friday', 'Specjalna oferta z okazji Black Friday', 2, 'sent', '2025-11-11 18:34:26', '2025-11-24 20:20:59'),
(3, 2, 'Noworoczna wyprzedaż', 'Wyprzedaż poświąteczna 2025', 3, 'sent', '2025-11-11 18:34:26', '2025-11-15 09:37:44'),
(4, 2, 'Przypomnienie o subskrypcji', 'E-mail przypominający o odnowieniu planu Pro', 4, 'scheduled', '2025-11-11 18:34:26', '2025-11-15 09:37:44'),
(5, 2, 'Ankieta satysfakcji klientów', 'Badanie opinii użytkowników po zakończeniu kampanii', 5, 'draft', '2025-11-11 18:34:26', '2025-11-15 09:37:44'),
(6, 2, 'Wladek', 'asdasda', 8, 'draft', '2025-11-16 23:45:07', '2025-11-16 23:45:07'),
(7, 2, 'Test', 'asdasdsa', 9, 'draft', '2025-11-17 19:22:14', '2025-11-17 19:22:14');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `clients`
--

CREATE TABLE `clients` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `user_id` int(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `clients`
--

INSERT INTO `clients` (`id`, `user_id`, `email`, `created_at`) VALUES
(1, 2, 'joraszmietek@gmail.com', '2025-11-17 18:34:24'),
(2, 2, 'mjorasz@interia.pl', '2025-11-17 18:34:24');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `emailtemplates`
--

CREATE TABLE `emailtemplates` (
  `id` int(11) NOT NULL,
  `title` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `html_template` mediumtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `updated_at` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `pre_made` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Zrzut danych tabeli `emailtemplates`
--

INSERT INTO `emailtemplates` (`id`, `title`, `html_template`, `created_at`, `updated_at`, `pre_made`) VALUES
(1, 'Dodosds', '<h1>Dodo</h1>', '2025-11-15 09:37:44', '2025-11-16 23:00:30', 0),
(2, 'Promocja Black Friday', '<html><body><h1>Black Friday 🔥</h1><p>Zniżki do 70% tylko dziś!</p></body></html>', '2025-11-15 09:37:44', '2025-11-15 09:37:44', 0),
(3, 'Noworoczna wyprzedaż', '<html><body><h1>Wyprzedaż Noworoczna 🎉</h1><p>Oszczędź nawet 50% na wybranych produktach!</p></body></html>', '2025-11-15 09:37:44', '2025-11-15 09:37:44', 0),
(4, 'Przypomnienie o subskrypcji', '<html><body><h1>Twoja subskrypcja wkrótce wygaśnie</h1><p>Odnow ją, aby zachować wszystkie funkcje!</p></body></html>', '2025-11-15 09:37:44', '2025-11-15 09:37:44', 0),
(5, 'Ankieta satysfakcji klientów', '<html><body><h1>Twoja opinia ma znaczenie!</h1><p>Wypełnij krótką ankietę i pomóż nam się rozwijać.</p></body></html>', '2025-11-15 09:37:44', '2025-11-15 09:37:44', 0),
(8, 'asdasdaasd', 'asdasdasd', '2025-11-16 23:45:07', '2025-11-16 23:45:07', 0),
(9, 'asdasdasd', 'sadasdasdasd', '2025-11-17 19:22:14', '2025-11-17 19:22:14', 0),
(10, 'Welcome Email', '<!doctype html>\r\n<html lang=\'pl\'>\r\n<head>\r\n<meta charset=\'utf-8\'>\r\n<meta name=\'viewport\' content=\'width=device-width,initial-scale=1\'>\r\n<title>Witamy</title>\r\n<style>\r\n  body { margin:0; padding:0; background:#f4f6f8; -webkit-text-size-adjust:100%; }\r\n  table { border-collapse:collapse; }\r\n  .container { width:100%; max-width:600px; margin:0 auto; background:#ffffff; }\r\n  .header { padding:24px; text-align:center; font-family:Arial, sans-serif; }\r\n  .hero { padding:20px; text-align:left; font-family:Arial, sans-serif; }\r\n  .btn { display:inline-block; padding:12px 20px; text-decoration:none; border-radius:6px; font-weight:600; }\r\n  .footer { padding:16px; font-size:12px; color:#777; text-align:center; font-family:Arial, sans-serif; }\r\n</style>\r\n</head>\r\n<body>\r\n  <center>\r\n    <table class=\'container\'>\r\n      <tr><td class=\'header\'>\r\n        <img src=\'https://via.placeholder.com/150x40?text=Logo\'>\r\n      </td></tr>\r\n      <tr><td class=\'hero\'>\r\n        <h1>Witaj, {{name}}!</h1>\r\n        <p>Dziękujemy za dołączenie do naszej aplikacji.</p>\r\n        <a href=\'{{cta_url}}\' class=\'btn\' style=\'background:#0b76ff;color:#fff;\'>Rozpocznij teraz</a>\r\n      </td></tr>\r\n      <tr><td class=\'footer\'>\r\n        <p>Jeśli nie chcesz otrzymywać wiadomości, <a href=\'{{unsubscribe_url}}\'>wypisz się</a>.</p>\r\n      </td></tr>\r\n    </table>\r\n  </center>\r\n</body>\r\n</html>', '2025-11-17 19:54:39', '2025-11-17 19:54:39', 1),
(11, 'Oferta Specjalna', '<!doctype html>\r\n<html lang=\'pl\'>\r\n<head>\r\n<meta charset=\'utf-8\'>\r\n<meta name=\'viewport\' content=\'width=device-width,initial-scale=1\'>\r\n<title>Oferta</title>\r\n<style>\r\n  body { margin:0; padding:0; background:#f2f7fb; font-family:Arial, sans-serif; }\r\n  .container { max-width:640px; margin:auto; background:#fff; }\r\n  .btn { padding:12px 22px; text-decoration:none; border-radius:6px; font-weight:700; }\r\n</style>\r\n</head>\r\n<body>\r\n<center>\r\n<table class=\'container\'>\r\n<tr><td>\r\n<img src=\'https://via.placeholder.com/640x220?text=Promocja\' style=\'width:100%;\'>\r\n</td></tr>\r\n<tr><td style=\'padding:20px;\'>\r\n<h2>Specjalna oferta!</h2>\r\n<p>Odbierz -30% z kodem <strong>SALE30</strong>.</p>\r\n<p>Ważne do {{expiry_date}}</p>\r\n<a href=\'{{cta_url}}\' class=\'btn\' style=\'background:#ff6b35;color:#fff;\'>Sprawdź ofertę</a>\r\n</td></tr>\r\n</table>\r\n</center>\r\n</body>\r\n</html>', '2025-11-17 19:54:56', '2025-11-17 19:54:56', 1),
(12, 'Newsletter', '<!doctype html>\r\n<html lang=\'pl\'>\r\n<head>\r\n<meta charset=\'utf-8\'>\r\n<meta name=\'viewport\' content=\'width=device-width,initial-scale=1\'>\r\n<title>Newsletter</title>\r\n<style>\r\n  body{background:#f8fafc;font-family:Arial;}\r\n  .wrapper{max-width:680px;margin:auto;background:#fff;}\r\n</style>\r\n</head>\r\n<body>\r\n<center>\r\n<table class=\'wrapper\'>\r\n<tr><td style=\'padding:18px;text-align:center;\'>\r\n<h1>Aktualności z {{company_name}}</h1>\r\n</td></tr>\r\n<tr><td style=\'padding:18px;\'>\r\n<h3>Artykuł 1</h3>\r\n<p>Krótki opis artykułu.</p>\r\n<a href=\'{{article1_url}}\'>Czytaj dalej →</a>\r\n</td></tr>\r\n</table>\r\n</center>\r\n</body>\r\n</html>', '2025-11-17 19:55:35', '2025-11-17 19:55:35', 1),
(13, 'Potwierdzenie Zamówienia', '<!doctype html>\r\n<html lang=\'pl\'>\r\n<head>\r\n<meta charset=\'utf-8\'>\r\n<meta name=\'viewport\' content=\'width=device-width,initial-scale=1\'>\r\n<title>Potwierdzenie zamówienia</title>\r\n<style>\r\n  body{background:#f3f5f7;font-family:Arial;}\r\n  .card{max-width:640px;margin:auto;background:#fff;}\r\n</style>\r\n</head>\r\n<body>\r\n<center>\r\n<table class=\'card\'>\r\n<tr><td style=\'text-align:center;padding:20px;\'>\r\n<h2>Dziękujemy za zamówienie, {{name}}!</h2>\r\n<p>Numer zamówienia: #{{order_number}}</p>\r\n</td></tr>\r\n</table>\r\n</center>\r\n</body>\r\n</html>', '2025-11-17 19:55:59', '2025-11-17 19:55:59', 1),
(14, 'Przypomnienie', '<!doctype html>\r\n<html lang=\'pl\'>\r\n<head>\r\n<meta charset=\'utf-8\'>\r\n<meta name=\'viewport\' content=\'width=device-width,initial-scale=1\'>\r\n<title>Przypomnienie</title>\r\n<style>\r\n  body{background:#eef3f7;font-family:Arial;}\r\n  .box{max-width:620px;margin:auto;background:#fff;}\r\n</style>\r\n</head>\r\n<body>\r\n<center>\r\n<table class=\'box\'>\r\n<tr><td style=\'padding:20px;text-align:center;\'>\r\n<h2>Przypomnienie</h2>\r\n<p>Cześć {{name}}, przypominamy o ustaleniach po spotkaniu.</p>\r\n<a href=\'{{schedule_url}}\' style=\'padding:12px 20px;background:#0b76ff;color:#fff;border-radius:6px;text-decoration:none;\'>\r\nUmów kolejne spotkanie\r\n</a>\r\n</td></tr>\r\n</table>\r\n</center>\r\n</body>\r\n</html>', '2025-11-17 19:56:21', '2025-11-17 19:56:21', 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `first_name` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `last_name` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `company_name` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `nip` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `company_address` text COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `country` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `subscription_plan` enum('free','pro','enterprise') COLLATE utf8mb4_unicode_ci DEFAULT 'free',
  `registration_date` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Zrzut danych tabeli `users`
--

INSERT INTO `users` (`id`, `first_name`, `last_name`, `email`, `password`, `company_name`, `nip`, `company_address`, `country`, `subscription_plan`, `registration_date`) VALUES
(1, '', '', 'joraszmietek@gmail.com', '$2b$10$WcxWwlfyIOdfVEX1E/mv6Oi68W/RUTru/NCFzfr6HoffsG1Kq8oCu', 'dfds', NULL, NULL, NULL, 'free', '2025-11-10 16:22:56'),
(2, '', '', 'mjorasz@interia.pl', '$2b$10$.xw2hxufhnf2WHhw9QYaYuVRG5jj7OpgazE4UiTuwQHkZZEI6FWEe', 'LensDodo', NULL, NULL, NULL, 'enterprise', '2025-11-10 17:15:26');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `campaigns`
--
ALTER TABLE `campaigns`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_id` (`user_id`),
  ADD KEY `title` (`title`),
  ADD KEY `fk_campaigns_email_template` (`email_template_id`);

--
-- Indeksy dla tabeli `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `emailtemplates`
--
ALTER TABLE `emailtemplates`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`),
  ADD KEY `email_2` (`email`),
  ADD KEY `subscription_plan` (`subscription_plan`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `campaigns`
--
ALTER TABLE `campaigns`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT dla tabeli `clients`
--
ALTER TABLE `clients`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT dla tabeli `emailtemplates`
--
ALTER TABLE `emailtemplates`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT dla tabeli `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `campaigns`
--
ALTER TABLE `campaigns`
  ADD CONSTRAINT `fk_campaigns_email_template` FOREIGN KEY (`email_template_id`) REFERENCES `emailtemplates` (`id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_campaigns_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
