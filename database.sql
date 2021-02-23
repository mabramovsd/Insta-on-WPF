--
-- PostgreSQL database dump
--

-- Dumped from database version 13.1
-- Dumped by pg_dump version 13.1

-- Started on 2021-02-23 19:52:21

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'WIN1251';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 207 (class 1259 OID 16979)
-- Name: CommentLikes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."CommentLikes" (
    "CommentId" integer NOT NULL,
    "UserId" integer NOT NULL
);


ALTER TABLE public."CommentLikes" OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 16939)
-- Name: Comments; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Comments" (
    "Id" integer NOT NULL,
    "UserId" integer,
    "PostId" integer,
    "Dt" date,
    "Text" character varying(1000)
);


ALTER TABLE public."Comments" OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 16937)
-- Name: Comments_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Comments_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Comments_Id_seq" OWNER TO postgres;

--
-- TOC entry 3032 (class 0 OID 0)
-- Dependencies: 204
-- Name: Comments_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Comments_Id_seq" OWNED BY public."Comments"."Id";


--
-- TOC entry 206 (class 1259 OID 16956)
-- Name: Likes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Likes" (
    "PostId" integer NOT NULL,
    "UserId" integer NOT NULL
);


ALTER TABLE public."Likes" OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 16923)
-- Name: Posts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Posts" (
    "Id" integer NOT NULL,
    "UserId" integer,
    "Photo" bytea,
    "Dt" date,
    "Text" character varying(1000)
);


ALTER TABLE public."Posts" OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 16921)
-- Name: Posts_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Posts_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Posts_Id_seq" OWNER TO postgres;

--
-- TOC entry 3033 (class 0 OID 0)
-- Dependencies: 202
-- Name: Posts_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Posts_Id_seq" OWNED BY public."Posts"."Id";


--
-- TOC entry 201 (class 1259 OID 16912)
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Id" integer NOT NULL,
    "Login" character varying(100) NOT NULL,
    "Password" character varying(100),
    "Photo" bytea,
    "Info" character varying(1000)
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 16910)
-- Name: Users_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Users_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Users_Id_seq" OWNER TO postgres;

--
-- TOC entry 3034 (class 0 OID 0)
-- Dependencies: 200
-- Name: Users_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Users_Id_seq" OWNED BY public."Users"."Id";


--
-- TOC entry 2875 (class 2604 OID 16942)
-- Name: Comments Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Comments" ALTER COLUMN "Id" SET DEFAULT nextval('public."Comments_Id_seq"'::regclass);


--
-- TOC entry 2874 (class 2604 OID 16926)
-- Name: Posts Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Posts" ALTER COLUMN "Id" SET DEFAULT nextval('public."Posts_Id_seq"'::regclass);


--
-- TOC entry 2873 (class 2604 OID 16915)
-- Name: Users Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users" ALTER COLUMN "Id" SET DEFAULT nextval('public."Users_Id_seq"'::regclass);


--
-- TOC entry 3026 (class 0 OID 16979)
-- Dependencies: 207
-- Data for Name: CommentLikes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."CommentLikes" ("CommentId", "UserId") FROM stdin;
\.


--
-- TOC entry 3024 (class 0 OID 16939)
-- Dependencies: 205
-- Data for Name: Comments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Comments" ("Id", "UserId", "PostId", "Dt", "Text") FROM stdin;
\.


--
-- TOC entry 3025 (class 0 OID 16956)
-- Dependencies: 206
-- Data for Name: Likes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Likes" ("PostId", "UserId") FROM stdin;
\.


--
-- TOC entry 3022 (class 0 OID 16923)
-- Dependencies: 203
-- Data for Name: Posts; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Posts" ("Id", "UserId", "Photo", "Dt", "Text") FROM stdin;
\.


--
-- TOC entry 3020 (class 0 OID 16912)
-- Dependencies: 201
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Users" ("Id", "Login", "Password", "Photo", "Info") FROM stdin;
\.


--
-- TOC entry 3035 (class 0 OID 0)
-- Dependencies: 204
-- Name: Comments_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Comments_Id_seq"', 1, false);


--
-- TOC entry 3036 (class 0 OID 0)
-- Dependencies: 202
-- Name: Posts_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Posts_Id_seq"', 1, false);


--
-- TOC entry 3037 (class 0 OID 0)
-- Dependencies: 200
-- Name: Users_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Users_Id_seq"', 1, false);


--
-- TOC entry 2881 (class 2606 OID 16978)
-- Name: Comments Comments_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Comments"
    ADD CONSTRAINT "Comments_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2879 (class 2606 OID 16931)
-- Name: Posts Posts_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Posts"
    ADD CONSTRAINT "Posts_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2877 (class 2606 OID 16920)
-- Name: Users Users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2888 (class 2606 OID 16987)
-- Name: CommentLikes comment_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."CommentLikes"
    ADD CONSTRAINT comment_fk FOREIGN KEY ("CommentId") REFERENCES public."Comments"("Id");


--
-- TOC entry 2884 (class 2606 OID 16951)
-- Name: Comments post_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Comments"
    ADD CONSTRAINT post_fk FOREIGN KEY ("PostId") REFERENCES public."Posts"("Id");


--
-- TOC entry 2886 (class 2606 OID 16964)
-- Name: Likes post_fk1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Likes"
    ADD CONSTRAINT post_fk1 FOREIGN KEY ("PostId") REFERENCES public."Posts"("Id");


--
-- TOC entry 2882 (class 2606 OID 16932)
-- Name: Posts user_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Posts"
    ADD CONSTRAINT user_fk FOREIGN KEY ("UserId") REFERENCES public."Users"("Id");


--
-- TOC entry 2883 (class 2606 OID 16946)
-- Name: Comments user_fk1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Comments"
    ADD CONSTRAINT user_fk1 FOREIGN KEY ("UserId") REFERENCES public."Users"("Id");


--
-- TOC entry 2885 (class 2606 OID 16959)
-- Name: Likes user_fk2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Likes"
    ADD CONSTRAINT user_fk2 FOREIGN KEY ("UserId") REFERENCES public."Users"("Id");


--
-- TOC entry 2887 (class 2606 OID 16982)
-- Name: CommentLikes user_fk3; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."CommentLikes"
    ADD CONSTRAINT user_fk3 FOREIGN KEY ("UserId") REFERENCES public."Users"("Id");


-- Completed on 2021-02-23 19:52:22

--
-- PostgreSQL database dump complete
--

