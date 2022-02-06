# Base image
FROM ruby:3.1-bullseye AS base

WORKDIR /app

COPY Gemfile Gemfile.lock .

RUN gem update --system && \
  bundle config set without 'development test' && \
  bundle

# Release image
FROM base AS release

COPY . .

# Dev image
FROM release AS dev

ENV TESTOPTS=--pride

RUN bundle config --delete without && \
  bundle

CMD rake test
