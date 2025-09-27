# Changelog

## [1.0.0] - 2025-09-27

Fork unity package repo to the custom IoC package.

## [0.7.0]

### Added
- Pooling
- Implicit and Weak Bindings

### Fixed
- Fix: bug on removal of first Context
- Fix: Fix to multiple context removal regarding false circular dependencies
- Fix: Fixed a race condition that allowed some Views to register before the Context was ready
- Fix: Fixed an EventDispatcher bug where a listener removed during Dispatch still receives callback.
- [Issue #56] Improved Context startup syntax
- [Issue #53] Exposing a checkbox that allows a View to not register with the Context
- [Issue #45] Fix for issue that could cause double-instantiation of a mapped Singleton
- [Issue #44] Prevent empty Constructors from improperly firing when a longer Constructor has been tagged as default
- [Issue #40] Fixes a null pointer when using CrossContext without MVCSContext
- [Issue #39] Add some porcelain methods to clarify View/Mediation binding behaviour
- [Issue #34] Fixed a bug where constructor injection resulted in NPE when mapped ToSingleton
- [Issue #13] Reflector now throws an Exception when attempting to inject into non-public setter
- [Issue #1] PostConstructs now support priority ordering

### Changed
- Change: Many methods that previously returned ‘object’ now return T.
- Change: MediationBinder now Mediates Views 'bottom-up' so that more deeply nested Views receive injection first.
- Change: Added a new exception to warn if accidentally mapped a View to something not a MonoBehaviour

## [0.6.0]

### Added
- New feature: Signals
- Improvement: Cross-Context support

v0.5.1a - To avoid errors on first install, renamed 'docs' to '.docs', which makes Unity ignore the folder.

v0.5.1 - Reorganized repo for simplicity/uniformity with Unity Asset Store. Deprecated Sequencer.

v0.5  - Initial public release
