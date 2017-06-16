FROM postgres:latest
EXPOSE 5432
COPY dbScript/10-init.sql /docker-entrypoint-initdb.d/10-init.sql